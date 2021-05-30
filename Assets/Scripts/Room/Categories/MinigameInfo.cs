using UnityEngine;

[CreateAssetMenu(fileName = "New MinigameInfo", menuName = "Minigame Info", order = 51)]
public class MinigameInfo : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private MiniGameName miniGameName;
    [SerializeField] private float time;
    [SerializeField] private Material roomMaterial;
    [Space(10)]
    [SerializeField] private bool useAnswerDomino;
    [SerializeField] private bool usePlaceForDomino;
    [SerializeField] private bool useMills;
    public int GetId()
    {
        return id;
    }

    public MiniGameName GetName()
    {
        return miniGameName;
    }

    public float GetTime()
    {
        return time;
    }

    public Material GetMaterial()
    {
        return roomMaterial;
    }

    public bool UseAnswerDomino()
    {
        return useAnswerDomino;
    }
    public bool UsePlaceForDomino()
    {
        return usePlaceForDomino;
    }
    public bool UseMills()
    {
        return useMills;
    }

}

public enum MiniGameName
{
    Math
}
