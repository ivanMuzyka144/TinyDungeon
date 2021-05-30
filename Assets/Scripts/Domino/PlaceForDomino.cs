using UnityEngine;
using Lean.Transition;

public class PlaceForDomino : MonoBehaviour
{
    [SerializeField] private DominoHolder myHolder;
    [SerializeField] private DominoPresenter dominoPresenter;

    private PlatformManager platformManager;
    private PlatformType currentPlatform;

    private DominoHolder dominoInZone;
    private Vector3 startDominoRotation;

    private void Start()
    {
        platformManager = PlatformManager.Instance;
        currentPlatform = platformManager.GetCurrentPlatform();
    }

    public bool HasDomino()
    {
        return dominoInZone != null;
    }

    public bool IsDominoCorrect()
    {
        Domino myDomino = myHolder.GetDomino();
        bool returnValue = false;
        if(dominoInZone != null)
        {
            Domino inZoneDomino = dominoInZone.GetDomino();
            if (myHolder.HasWholeValue())
            {
                returnValue = inZoneDomino.EquealToWholeDomino(myDomino);
            }
            else
            {
                returnValue = inZoneDomino.EquealToNormalDomino(myDomino);
            }
        }
        return returnValue;
    }

    public void HideText()
    {
        dominoPresenter.HideText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null 
            && currentPlatform != PlatformType.Console)
        {
            if(dominoInZone == null) 
            {
                AddDomino(other.GetComponent<DominoHolder>());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null 
            && other.GetComponent<DominoHolder>() == dominoInZone
            && currentPlatform != PlatformType.Console)
        {
            RemoveDomino();
        }
    }

    public void AddDomino(DominoHolder otherDomino)
    {
        dominoInZone = otherDomino.GetComponent<DominoHolder>();
        dominoInZone.SetPlaceForDomino(this);
        dominoInZone.transform.rotationTransition(transform.rotation, 0.25f);
        dominoInZone.GetComponent<DominoAnimator>().MakeRotation(transform.eulerAngles);
    }

    public void RemoveDomino()
    {
        if (dominoInZone != null)
        {
            dominoInZone.RemovePlaceForDominoPosition(this);
            dominoInZone.GetComponent<DominoAnimator>().MakeNormalRotation();
            dominoInZone = null;
        }
        
    }
    
}
