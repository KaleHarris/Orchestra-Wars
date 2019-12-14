using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyWaveManager : MonoBehaviour
{
    public static AllyWaveManager Instance;
    public List<AllyWave> allyWaves = new List<AllyWave>();
    private float elapsedTime = 0f;
    private AllyWave activeWave;
    private float spawnCounter = 0f;
    private List<AllyWave> activatedWaves = new List<AllyWave>();

    void Awake() {
        Instance = this;
    }

    void Start(){

    }

    void Update() {
        if (GameManager.instance.isPaused != true){
        elapsedTime += Time.deltaTime;
        SearchForWave();
        UpdateActiveWave();
        //stops spawning when a boss has arrived
        if (GameManager.instance.bossSpawned){
            StopSpawning();
        }
        }
    }
    private void SearchForWave() {
        foreach (AllyWave allyWave in allyWaves)
        {
            if (!activatedWaves.Contains(allyWave) && allyWave.startSpawnTimeInSeconds <= elapsedTime) {
                activeWave = allyWave;
                activatedWaves.Add(allyWave);
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

                if (activeWave.listOfAllies.Count != 0) {

                GameObject ally = (GameObject)Instantiate(
                activeWave.listOfAllies[0], WayPointManager.Instance.
                GetSpawnPosition(activeWave.pathIndex), Quaternion.identity);

                ally.GetComponent<AllyScript>().pathIndex = activeWave.pathIndex;

                activeWave.listOfAllies.RemoveAt(0);
                } else {

                activeWave = null;

                if (activatedWaves.Count == allyWaves.Count) {

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
