using UnityEngine;

[CreateAssetMenu(fileName = "LevelConnection", menuName = "Scriptable Objects/LevelConnection")]
public class LevelConnection : ScriptableObject
{
    public static LevelConnection _activeConnection { get; set; }
}
