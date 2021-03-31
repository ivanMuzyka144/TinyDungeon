using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionChecker : MonoBehaviour
{
    public abstract void Configurate(Topology topology);

    public abstract ConditionResult CheckCondition();
}

public enum ConditionResult
{
    NotReady,
    Win,
    Lose
}
