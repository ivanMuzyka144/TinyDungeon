using UnityEngine;
using Lean.Transition;

public class DoorSelector : MonoBehaviour, ISelectable
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private float selectionHeight;
    [SerializeField] private float selectionHeightTime;
    [Space(10)]
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Door door;

    private GameStateManager gameStateManager;

    private bool isActive;
    private bool isSelected;

    private Vector3 startPosition;
    private Vector3 finishPosition;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
    }

    public void Enable()
    { 
        isActive = true;

        startPosition = transform.position;
        finishPosition = transform.position + new Vector3(0, selectionHeight, 0);
    }

    public void Disable()
    {
        isActive = false;
        isSelected = false;
        meshRenderer.material = defaultMaterial;
    }

    public void OnSelected()
    {
        if (isActive && !isSelected)
        {
            isSelected = true;
            meshRenderer.material = selectedMaterial;
            transform.positionTransition(finishPosition, selectionHeightTime);
        }
    }

    public void OnDeselected()
    {
        if (isActive)
        {
            isSelected = false;
            meshRenderer.material = defaultMaterial;
            transform.positionTransition(startPosition, selectionHeightTime);
        }
    }

    public void OnStillSelected()
    {
        if (isActive)
        {
            OnSelected();
        }
    }

    public void OnMouseDown()
    {
        MakeSelectionAction();
    }

    

    public bool IsSelected()
    {
        return isSelected;
    }

    public void MakeSelectionAction()
    {
        if (isActive)
        {
            door.OnDoorSelected();
        }
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
