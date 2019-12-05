using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusic : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
