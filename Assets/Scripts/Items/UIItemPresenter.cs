using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class UIItemPresenter : MonoBehaviour
{
    public static UIItemPresenter Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI miracleText;
    [Space(10)]
    [SerializeField] private Item lifeItem;
    [SerializeField] private Item coinItem;
    [SerializeField] private Item miracleItem;
    private void Awake() => Instance = this;

    public void UpdatePresenter(List<Item> collectedItems)
    {
        int lifeCount = collectedItems.Where(n => n == lifeItem).ToList().Count;
        int coinCount = collectedItems.Where(n => n == coinItem).ToList().Count;
        int miracleCount = collectedItems.Where(n => n == miracleItem).ToList().Count;

        lifeText.text = lifeCount + "";
        coinText.text = coinCount + "";
        miracleText.text = miracleCount + "";
    }
}
