using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySheetMusic : MonoBehaviour
{
    public GameObject player;
    //public GameObject enemyBoss;
    GameObject sheetMusic;
    GameObject text;
    //bool bossFound = false;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(player.transform);
        /*if (bossFound == false){
            SearchForBoss();
        }
        if (bossFound == true){
            transform.position = enemyBoss.carryPoint.transform.position;
        }
    }
    void SearchForBoss(){
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("EnemyBoss")){
                enemyBoss = i;
        }
        if (enemyBoss != null){
            bossFound = true;
        }*/
    }
}
