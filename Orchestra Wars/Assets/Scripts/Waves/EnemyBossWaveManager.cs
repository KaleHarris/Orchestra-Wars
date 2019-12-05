using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossWaveManager : MonoBehaviour
{
    public static EnemyBossWaveManager Instance;
    public List<EnemyBossWave> enemyBossWaves = new List<EnemyBossWave>();
    private float elapsedTime = 0f;
    private EnemyBossWave activeWave;
    private float spawnCounter = 0f;
    private List<EnemyBossWave> activatedWaves = new List<EnemyBossWave>();

    void Awake() {
        Instance = this;
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        SearchForWave();
        UpdateActiveWave();
    }
    private void SearchForWave() {
        foreach (EnemyBossWave enemyBossWave in enemyBossWaves)
        {
            if (!activatedWaves.Contains(enemyBossWave) && enemyBossWave.startSpawnTimeInSeconds <= elapsedTime) {
                activeWave = enemyBossWave;
                activatedWaves.Add(enemyBossWave);
                spawnCounter = 0f;
                break;
            }
        }
    }

    private void UpdateActiveWave() {
        
        if (activeWave != null) {
        spawnCounter += Time.deltaTime;

            if (spawnCounter >= activeWave.timeBetweenSpawnsInSeconds) {
            spawnCounter = 0f;

                if (activeWave.listOfEnemyBosses.Count != 0) {

                GameObject enemyBoss = (GameObject)Instantiate(
                activeWave.listOfEnemyBosses[0], WayPointManager.Instance.
                GetSpawnPosition(activeWave.pathIndex), Quaternion.identity);

                enemyBoss.GetComponent<EnemyBossScript>().pathIndex = activeWave.pathIndex;

                activeWave.listOfEnemyBosses.RemoveAt(0);
                } else {

                activeWave = null;

                if (activatedWaves.Count == enemyBossWaves.Count) {

                }
            }
        }
    }
    }
    public void StopSpawning() {
        elapsedTime = 0;
        spawnCounter = 0;
        activeWave = null;
        activatedWaves.Clear();
        enabled = false;
    }
}
