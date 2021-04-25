using UnityEngine;

[CreateAssetMenu(fileName = "New MinigameInfo", menuName = "Minigame Info", order = 51)]
public class MinigameInfo : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private MiniGameName miniGameName;
    [SerializeField] private float time;
    [SerializeField] private Material roomMaterial;

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
}

public enum MiniGameName
{
    Math
}
