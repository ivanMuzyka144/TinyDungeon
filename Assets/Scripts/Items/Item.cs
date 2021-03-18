using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]
public class Item : ScriptableObject
{
    [SerializeField] public string name;
}
