using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "Level", menuName = "GameSO/Level")]

public class LevelData : ScriptableObject
{
    public List<Wave> waves = new List<Wave>();
}

[System.Serializable]

public class Wave
{
    public Enemy EnemyPrefab;
    [Range(1, 100)]
    public int CountInWave;
    [Range (1, 360)]
    public int WaitAfterWave;
    [Range(0.1f, 10f)]
    public float SpawnCD;
}