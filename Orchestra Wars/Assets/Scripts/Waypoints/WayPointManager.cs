using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public static WayPointManager Instance;
    public List<MinionPath> MinionPaths = new List<MinionPath>();
    void Awake()
    {
        Instance = this;
    }

    public Vector3 GetSpawnPosition(int pathIndex) {
        return MinionPaths[pathIndex].WayPoints[0].position;
    }
}
[System.Serializable]
public class MinionPath {
    public List<Transform> WayPoints = new List<Transform>();
}
