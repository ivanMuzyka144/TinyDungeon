using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemPresenter : MonoBehaviour
{
    public void MakeEffectFor(Item item)
    {
        Debug.Log("You got a " + item.name);
    }
}
