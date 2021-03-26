using UnityEngine;

public class DifficultySimulator : MonoBehaviour
{
    public static DifficultySimulator Instance { get; private set; }

    [SerializeField] private DifficultyType difficultyType;

    private void Awake() => Instance = this;
    public DifficultyType GetDifficultyType()
    {
        return difficultyType;
    }
}

public enum DifficultyType
{
    Easy,
    Medium,
    Hard,
    Madness
}