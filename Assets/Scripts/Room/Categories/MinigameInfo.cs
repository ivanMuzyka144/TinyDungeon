using UnityEngine;

[CreateAssetMenu(fileName = "New MinigameInfo", menuName = "Minigame Info", order = 51)]
public class MinigameInfo : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private float time;
}
