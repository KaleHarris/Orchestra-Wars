using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    int speed = 10;

    void Update()
    {
        if (target == null){
            Destroy(gameObject);
        } else if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.LookAt(target.transform.position);
            if (Vector3.Distance(transform.position, target.transform.position) < 0.2) {
                Destroy(gameObject);
            }
        }
    }
}
