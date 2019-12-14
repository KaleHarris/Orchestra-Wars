using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject TurretPos;
    public GameObject Turret;
    bool exists = false;
    Vector3 recede = new Vector3(0, 0, 1);

    void Update()
    {

    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Hand") && exists == false){
            SpawnTurret();
            transform.position += recede;
        }
    }

    public void SpawnTurret(){
        if (exists == false){
            Instantiate(Turret, TurretPos.GetComponent<Transform>().transform);
            exists = true;
        }
    }
}
