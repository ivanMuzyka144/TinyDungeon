using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    public static PostProcessingManager Instance { get; private set; }

    [SerializeField] private PostProcessVolume volume;

    private DepthOfField depthOfField;

    private void Awake()
    { 
        Instance = this;
        depthOfField = null;
        volume.profile.TryGetSettings(out depthOfField);
    }

    public void FocusOnDomino()
    {
        
        //depthOfField.active = true;
        float from = 20;
        float to = 14.66f;
        float time = 1f;

        LeanTween.value(gameObject, SetDepthOfFieldValue, from, to, time);
    }
    public void FocusOnRoom()
    {

        //depthOfField.active = false;

        float from = 14.66f;
        float to = 20.0f;
        float time = 1f;

        LeanTween.value(gameObject, SetDepthOfFieldValue , from, to, time);

    }

    private void SetDepthOfFieldValue(float value)
    {
        depthOfField.focusDistance.value = value;
    }
}
