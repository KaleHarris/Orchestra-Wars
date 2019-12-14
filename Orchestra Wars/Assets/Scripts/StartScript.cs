using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject menu;
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Hand")){
            GameManager.instance.isPaused = false;
            Destroy(menu);
        }
    }
}
