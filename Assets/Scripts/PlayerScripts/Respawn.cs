﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 RespawnPoint;
    public int LifeBar;
    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = transform.position;
        LifeBar = 25;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided");
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("damaged");
            LifeBar -= 1;
            if (LifeBar <= 0)
            {
                Debug.Log("killed");
                transform.position = RespawnPoint;
                LifeBar = 25;
            }
        }
        else if(other.gameObject.tag == "DeathTrap")
        {
            Debug.Log("instakilled");
            transform.position = RespawnPoint;
            LifeBar = 25;
        }
        else if (other.gameObject.tag == "SavePoint")
        {
            Debug.Log("saved");
            RespawnPoint = other.gameObject.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
