using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int allyMinionCount = 0;
    public int enemyMinionCount = 0;
    public bool bossSpawned = false;
    public bool spawnAllyBoss = false;
    public bool spawnEnemyBoss = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allyMinionCount >= 20){
            bossSpawned = true;
            spawnAllyBoss = true;
        } else if (enemyMinionCount >= 20){
            bossSpawned = true;
            spawnEnemyBoss = true;
        }
    }
}
