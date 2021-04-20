using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused = true;
    public bool endGame = false;
    public int allyMinionCount = 0;
    public int enemyMinionCount = 0;
    public bool bossSpawned = false;
    public bool spawnAllyBoss = false;
    public bool playerWin = false;
    public bool spawnEnemyBoss = false;
    public bool enemyWin = false;
    public bool quitSpawned = false;
    bool enemyBossFound;
    bool allyBossFound;
    public GameObject player;
    public GameObject allyText;
    public GameObject enemyText;
    public GameObject timeText;
    public GameObject quitPos;
    public GameObject quitButton;
    public GameObject enemyBoss;
    public GameObject allyBoss;
    public AudioSource music;
    bool musicStarted = false;
    float currentTime = 300;

    void Start()
    {
        if (instance == null){
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        allyText.GetComponent<TextMesh>().text = "Allies in Enemy Base: " + allyMinionCount + "/20";
        enemyText.GetComponent<TextMesh>().text = "Enemies in Your Base: " + enemyMinionCount + "/20";
        if (isPaused == false){
            currentTime -= Time.deltaTime;
            timeText.GetComponent<TextMesh>().text = "Time Left: " + currentTime + " seconds";
        }
        if (isPaused == false && musicStarted == false){
            music.Play();
            musicStarted = true;
        }
        if (allyMinionCount >= 20){
            bossSpawned = true;
            spawnAllyBoss = true;
        }
        if (enemyMinionCount >= 20){
            bossSpawned = true;
            spawnEnemyBoss = true;
        }
        //conditions for triggering the different end games
        if (currentTime <= 0){
            endGame = true;
        }
        if (endGame == true && playerWin == true && quitSpawned == false){
            isPaused = true;
            timeText.GetComponent<TextMesh>().text = "You stole the enemy's Sheet Music! You Win!\nCome to the bridge to quit the game!";
            Instantiate(quitButton, quitPos.GetComponent<Transform>().transform);
            quitSpawned = true;
        }else if (endGame == true && enemyWin == true && quitSpawned == false){
            isPaused = true;
            timeText.GetComponent<TextMesh>().text = "The enemy stole your Sheet Music! You Lose!\nCome to the bridge to quit the game!";
            Instantiate(quitButton, quitPos.GetComponent<Transform>().transform);
            quitSpawned = true;
        }else if (endGame == true && currentTime <= 0 && quitSpawned == false) {
            isPaused = true;
            timeText.GetComponent<TextMesh>().text = "Time has run out! It's a Draw!\nCome to the bridge to quit the game!";
            Instantiate(quitButton, quitPos.GetComponent<Transform>().transform);
            quitSpawned = true;
        }
        //end conditions for triggering end games
    }
    void SearchForEnemyBoss(){
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("EnemyBoss")){
                enemyBoss = i;
        }
        if (enemyBoss != null){
            enemyBossFound = true;
        }
    }
    void SearchForAllyBoss(){
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("AllyBoss")){
                allyBoss = i;
        }
        if (allyBoss != null){
            allyBossFound = true;
        }
    }
}
