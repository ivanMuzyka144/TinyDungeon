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
    // 20 5.5 10 1.5
    public void FocusOnDomino()
    {
        
        //depthOfField.active = true;
        float fromFocusDistance = 15;
        float fromAperture = 5.5f;
        float toFocusDistance = 5.5f;
        float toAperture = 0.8f;
        float time = 1f;

        LeanTween.value(gameObject, SetDepthOfFieldValue, fromFocusDistance, toFocusDistance, time);
        LeanTween.value(gameObject, SetAperture, fromAperture, toAperture, time);
    }
    public void FocusOnRoom()
    {
        float toFocusDistance = 15;
        float toAperture = 5.5f;
        float fromFocusDistance = 5.5f;
        float fromAperture = 0.8f;
        float time = 1f;

        LeanTween.value(gameObject, SetDepthOfFieldValue, fromFocusDistance, toFocusDistance, time);
        LeanTween.value(gameObject, SetAperture, fromAperture, toAperture, time);
    }

    private void SetDepthOfFieldValue(float value)
    {
        depthOfField.focusDistance.value = value;
    }

    private void SetAperture(float value)
    {
        depthOfField.aperture.value = value;
    }
}
