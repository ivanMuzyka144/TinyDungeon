using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [Space(10)]
    [SerializeField] private float howMany;

    public List<Item> GenerateItems()//AddKeys
    {
        List<Item> generatedItems = new List<Item>();
        for(int i = 0; i<howMany; i++)
        {
            generatedItems.Add(items[Random.Range(0, items.Count)]);
        }
        return generatedItems;
    }


}
