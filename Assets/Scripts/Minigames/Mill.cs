using System;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour
{
    [SerializeField] private DominoSelector millsSelector;
    [SerializeField] private MillsRotator millsRotator;
    [SerializeField] private List<DominoHolder> dominoHolders = new List<DominoHolder>();
    
    public EventHandler OnMillRotated;
    public void EnableSelector() => millsSelector.Enable();
    public void EnableRotator() => millsRotator.Enable();
    public void DisableSelector() => millsSelector.Disable();
    public void DisableRotator() => millsRotator.Disable();

    public void OnMillHasRotated()
    {
        OnMillRotated?.Invoke(this, EventArgs.Empty);
    }

    public DominoHolder GetDominoHolder(int number)
    {
        int shiftValue = millsRotator.GetRotationCount();

        int realNumb = number - shiftValue;

        if(realNumb < 0)
        {
            realNumb += 4;
        }

        return dominoHolders[realNumb];
    }

    public ISelectable GetSelector()
    {
        return millsSelector;
    }
}
