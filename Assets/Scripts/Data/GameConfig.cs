using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "SO/Data/GameConfig", order = 0)]
public class GameConfig : ScriptableObject 
{
    [field: SerializeField] public PlayerSettings PlayerSettings {get; private set;}
}


[Serializable]
public class PlayerSettings
{
    [field: SerializeField] public GameObject Prefab {get; private set;}
    [field: SerializeField] public Color RedTeamColor { get; private set; } = Color.red;
    [field: SerializeField] public Color BlueTeamColor { get; private set; } = Color.blue;
}
