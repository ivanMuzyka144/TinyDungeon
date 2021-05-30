using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public static ItemCollection Instance { get; private set; }

    [SerializeField] private Item lifeItem;
    [SerializeField] private Item miracleItem;
    [SerializeField] private Item coinItem;
    [SerializeField] private Item keyItem;

    private void Awake() => Instance = this;

    public Item GetLifeItem()
    {
        return lifeItem;
    }
    public Item GetMiracleItem()
    {
        return miracleItem;
    }

    public Item GetCoinItem()
    {
        return coinItem;
    }

    public Item GetKeyItem()
    {
        return keyItem;
    }

}
