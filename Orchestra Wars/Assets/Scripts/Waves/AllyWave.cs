using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllyWave {
    public int pathIndex;
    public float startSpawnTimeInSeconds;
    public float timeBetweenSpawnsInSeconds = 1f;
    public List<GameObject> listOfAllies = new List<GameObject>();
}