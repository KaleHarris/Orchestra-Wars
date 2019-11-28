using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject TurretPos;
    public GameObject Turret;
    bool exists = false;

    void Update()
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed){
            SpawnTurret();
        }
    }

    public void SpawnTurret(){
        if (exists == false){
            Instantiate(Turret, TurretPos.GetComponent<Transform>().transform);
            exists = true;
        }
    }
}
