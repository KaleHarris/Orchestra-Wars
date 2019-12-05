using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyBossWave {
    public int pathIndex;
    public float startSpawnTimeInSeconds;
    public float timeBetweenSpawnsInSeconds = 1f;
    public List<GameObject> listOfEnemyBosses = new List<GameObject>();
}