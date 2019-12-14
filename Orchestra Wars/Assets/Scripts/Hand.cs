using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject playerHand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerHand.transform.position;
    }
}
