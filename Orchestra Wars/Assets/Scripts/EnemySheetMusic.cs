using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySheetMusic : MonoBehaviour
{
    public GameObject player;
    public GameObject allyBoss;
    bool bossFound;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(player.transform);
        if (bossFound == false){
            SearchForBoss();
        }
        if (bossFound == true){
            transform.position = allyBoss.transform.position;
        }
    }
    void SearchForBoss(){
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("AllyBoss")){
                allyBoss = i;
        }
        if (allyBoss != null){
            bossFound = true;
        }
    }
}
