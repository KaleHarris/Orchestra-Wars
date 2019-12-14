using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused = false;
    public bool endGame = false;
    public int allyMinionCount = 0;
    public int enemyMinionCount = 0;
    public bool bossSpawned = false;
    public bool spawnAllyBoss = false;
    public bool spawnEnemyBoss = false;

    void Start()
    {
        if (instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (OVRInput.GetDown(OVRInput.Button.One) && isPaused == true && endGame != true){
            isPaused = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.One) && isPaused != true && endGame != true){
            isPaused = true;
        }
        if (allyMinionCount >= 20){
            bossSpawned = true;
            spawnAllyBoss = true;
        }
        if (enemyMinionCount >= 20){
            bossSpawned = true;
            spawnEnemyBoss = true;
        }
    }
}
