using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBossWaveManager : MonoBehaviour
{
    public static AllyBossWaveManager Instance;
    public List<AllyBossWave> allyBossWaves = new List<AllyBossWave>();
    public GameObject gameManager;
    private float elapsedTime = 0f;
    private AllyBossWave activeWave;
    private float spawnCounter = 0f;
    private List<AllyBossWave> activatedWaves = new List<AllyBossWave>();

    void Awake() {
        Instance = this;
    }

    void Start(){
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("GameController")){
        gameManager = i;
        }
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        SearchForWave();
        UpdateActiveWave();
    }
    private void SearchForWave() {
        foreach (AllyBossWave allyBossWave in allyBossWaves)
        {
            if (!activatedWaves.Contains(allyBossWave) && gameManager.GetComponent<GameManager>().spawnAllyBoss == true) {
                activeWave = allyBossWave;
                activatedWaves.Add(allyBossWave);
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

                if (activeWave.listOfAllyBosses.Count != 0) {

                GameObject allyBoss = (GameObject)Instantiate(
                activeWave.listOfAllyBosses[0], WayPointManager.Instance.
                GetSpawnPosition(activeWave.pathIndex), Quaternion.identity);

                allyBoss.GetComponent<AllyBossScript>().pathIndex = activeWave.pathIndex;

                activeWave.listOfAllyBosses.RemoveAt(0);
                } else {

                activeWave = null;

                if (activatedWaves.Count == allyBossWaves.Count) {

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
