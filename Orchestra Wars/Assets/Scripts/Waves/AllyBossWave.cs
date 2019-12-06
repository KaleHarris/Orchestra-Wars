using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllyBossWave {
    public int pathIndex;
    public float timeBetweenSpawnsInSeconds = 1f;
    public List<GameObject> listOfAllyBosses = new List<GameObject>();
}
