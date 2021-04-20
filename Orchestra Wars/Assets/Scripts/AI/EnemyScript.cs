using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int pathIndex = 0;
    private int wayPointIndex = 0;
    public int speed = 2;
    public float health = 5;
    float maxHealth = 5;
    public GameObject healthUI;
    public Slider healthBar;
    public AudioSource hitSound;

    void Start(){
        healthBar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPaused != true){
        if (wayPointIndex < WayPointManager.Instance.MinionPaths[pathIndex].WayPoints.Count){
            UpdateMovement();
        }else {
            OnGotToLastWayPoint();
        }
        }
    }
    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("Projectile") || other.CompareTag("Weapon")){
            if (health > 1) {
                health -= 1;
                hitSound.Play();
                healthBar.value = health / maxHealth;
            } else{
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
        GameManager.instance.enemyMinionCount += 1;
        Destroy(gameObject);
    }
}
