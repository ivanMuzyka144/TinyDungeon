using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using System;

public class Blinker : MonoBehaviour
{
    [SerializeField] private DominoSelector dominoSelector;
    [SerializeField] private DominoHolder dominoHolder;
    [SerializeField] private MeshRenderer meshRenderer;
    [Space(10)]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color blinkColor;
    [Space(10)]
    [SerializeField] private float towardTime;
    [SerializeField] private float backTime;
    [SerializeField] private float delayTime;

    private bool canBlink;
    private bool isBlinking;

    private SequenceRecorder sequenceRecorder;

    public void OnEnable()
    {
        sequenceRecorder = SequenceRecorder.Instance;
    }
    public void Enable() => canBlink = true;
    public void Disable() => canBlink = false;

    private void Update()
    {
        if (canBlink)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)
                && dominoSelector.IsSelected()
                && !dominoSelector.IsBlocked()
                && isBlinking == false
                && !sequenceRecorder.IsBlinkingShowing())
            {
                isBlinking = true;
                MakeRecordedBlink();
            }
        }
    }

    public void MakeRecordedBlink()
    {
        Action afterAnimAction = () =>
        {
            isBlinking = false;
            MakeNomalMaterial();
            sequenceRecorder.EndShowingStatus();
            sequenceRecorder.Record(this);
            dominoHolder.OnDominoBlinked.Invoke(this, EventArgs.Empty);
        };
        sequenceRecorder.StartShowingStatus();
        MakeBlinkMaterial();
        Vector3 scale = transform.localScale;
        transform.localScaleTransition(scale + new Vector3(0.5f, 0.5f, 0.5f), towardTime)
                 .JoinDelayTransition(delayTime).localScaleTransition(scale, backTime)
                 .EventTransition(afterAnimAction, towardTime + delayTime + backTime);
        
    }
    public void MakeLastBlink()
    {
        Action afterAnimAction = () =>
        {
            isBlinking = false;
            sequenceRecorder.EndShowingStatus();
            MakeNomalMaterial();
        };

        MakeBlinkMaterial();
        Vector3 scale = transform.localScale;
        transform.localScaleTransition(scale + new Vector3(1f, 1f, 1f), towardTime)
                 .JoinDelayTransition(delayTime).localScaleTransition(scale, backTime)
                 .EventTransition(afterAnimAction, towardTime + delayTime + backTime);
    }

    public void MakeBlink(Action afterAnimAction)
    {
        MakeBlinkMaterial();
        Vector3 scale = transform.localScale;
        transform.localScaleTransition(scale + new Vector3(1f, 1f, 1f), towardTime)
                 .JoinDelayTransition(delayTime).localScaleTransition(scale, backTime)
                 .EventTransition(afterAnimAction, towardTime + delayTime + backTime);
    }

    public void MakeBlinkMaterial() => meshRenderer.material.color = blinkColor;

    public void MakeNomalMaterial() => meshRenderer.material.color = defaultColor;
    //public void MakeBlink()
    //{
    //    meshRenderer.material.color = blinkColor;
    //    dominoHolder.OnDominoHasClicked();
    //    StartCoroutine(BlinkCoroutine());
        
    //}

    //IEnumerator BlinkCoroutine()
    //{
    //    yield return new WaitForSeconds(1);
    //    meshRenderer.material.color = defaultColor;
    //    isBlinking = false;
    //}

}
