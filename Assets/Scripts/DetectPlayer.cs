﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool detected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("collided");
        if (other.gameObject.tag == "Player")
        {
            detected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("collided");
        if (other.gameObject.tag == "Player")
        {
            detected = false;
        }
    }
}
