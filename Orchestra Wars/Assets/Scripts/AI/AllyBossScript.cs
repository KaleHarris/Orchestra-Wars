using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBossScript : MonoBehaviour
{
    public int pathIndex = 0;
    private int wayPointIndex = 0;
    public int speed = 1;
    public int health = 40;
    public GameObject carryPoint;
    public GameObject enemyScroll;
    bool scrollFound;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        //search for and assign the opposing scroll to the enemy scroll variable, then change its transform to the carry point
        if (scrollFound == false){
            SearchForScroll();
        }
        if (scrollFound == true){
            enemyScroll.transform.position = carryPoint.transform.position;
        }
        //end scroll searching

        if (GameManager.instance.isPaused != true){
        if (wayPointIndex < WayPointManager.Instance.MinionPaths[pathIndex].WayPoints.Count){
            UpdateMovement();
        }else {
            OnGotToLastWayPoint();
        }
        }
    }
    void SearchForScroll(){
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("EnemyScroll")){
                enemyScroll = i;
        }
        if (enemyScroll != null){
            scrollFound = true;
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Projectile")){
            if (health > 1) {
                health -= 1;
            } else{
                GameManager.instance.enemyWin = true;
                GameManager.instance.endGame = true;
                Destroy(gameObject);
            }
        }
    }
    public void UpdateMovement(){
        Vector3 targetPosition = WayPointManager.Instance.MinionPaths[pathIndex].WayPoints[wayPointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);
        if (Vector3.Distance(transform.position, targetPosition) < .1f) {
            wayPointIndex++;
        }
    }
    private void OnGotToLastWayPoint(){
        GameManager.instance.playerWin = true;
        GameManager.instance.endGame = true;
        
    }
}
