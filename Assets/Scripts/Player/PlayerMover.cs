using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public void SpawnPlayer(Vector3 position) => transform.position = position;
    
}
