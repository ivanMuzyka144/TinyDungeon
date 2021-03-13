using UnityEngine;

public class DoorSelector : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;

    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Door door;


    private bool isActive;

    public void Enable() => isActive = true;
    public void Disable()
    {
        isActive = false;
        meshRenderer.material = defaultMaterial;
    }

    public void OnSelected()
    {
        if (isActive)
        {
            meshRenderer.material = selectedMaterial;
        }
    }

    public void OnDeselected()
    {
        if (isActive)
        {
            meshRenderer.material = defaultMaterial;
        }
    }

    public void OnMouseDown()
    {
        if (isActive)
        {
            door.OnDoorSelected();
        }
    }

}
