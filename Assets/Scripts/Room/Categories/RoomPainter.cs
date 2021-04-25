using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPainter : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> objectsForColoring = new List<MeshRenderer>();

    public void ColorObjects(MinigameInfo minigameInfo)
    {
        foreach(MeshRenderer meshRenderer in objectsForColoring)
        {
            meshRenderer.material = minigameInfo.GetMaterial();
        }
    }
}
