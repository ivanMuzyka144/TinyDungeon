﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public static ItemCollection Instance { get; private set; }

    [SerializeField] private Item lifeItem;
    [SerializeField] private Item miracleItem;
    [SerializeField] private Item coinItem;

    private void Awake() => Instance = this;

    public Item GetLifeItem()
    {
        return lifeItem;
    }
    public Item GetMiracleItem()
    {
        return miracleItem;
    }

}
