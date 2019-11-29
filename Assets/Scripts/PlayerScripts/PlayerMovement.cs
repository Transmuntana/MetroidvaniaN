﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D Control;
    float HMov = 0f;
    public float Accel = 1f;
    public float Brake = 2f;
    public float BaseAcc = 10f;
    public float TopSpd = 40f;
    float HSpd;
    bool Jump = false;
    bool Crouch = false;
    bool Pivoting = false;
    float LHMov = 0f;
    int JumpCount;
    bool JumpStart = false;
    public float Drag;

    public Rigidbody2D playerBody;
    public float fallSpeedCap = 125;
    public float jumpForce = 20;
    int counter;
    // Update is called once per frame

    //Update with no physics, FixedUpdate with physics
    void Update() {
       LHMov = HMov;
       HMov = Input.GetAxisRaw("Horizontal");
        if (LHMov * HMov < 0)
        {
            //PIVOTING
            Pivoting = true;
        }
        else Pivoting = false;


        if (!Pivoting && (Input.GetButtonDown("Horizontal")))
        {
            HSpd += BaseAcc;
        }
        else if (Pivoting && (Input.GetButtonDown("Horizontal")))
            {
                HSpd -= BaseAcc;
            }
        if (Input.GetButton("Horizontal"))
        {
            if (HSpd < TopSpd)
            {
                HSpd += Accel;
                
            }
        }
        else
        {
            if (HSpd > 0)
            {
                HSpd -= Brake;

            }
        }
        //control.Move(2, false, false);
        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            JumpStart = true;
        }
        if (Input.GetButton("Crouch"))
        {
            Crouch = true;
        }
        else Crouch = false;

        if (HSpd > TopSpd)
        {
            HSpd = TopSpd;
        }
        if (HSpd < 0)
        {
            HSpd = 0;
        }
    }
    void FixedUpdate()
    {

        Control.Move(HMov*HSpd*Time.fixedDeltaTime, Crouch, JumpStart);
        JumpStart = false;
        if (Jump)
        {
            JumpCount++;
            playerBody.AddForce(new Vector2(0f, -Drag));
            if (JumpCount > 3)
            {
                Jump = false;
                JumpCount = 0;
            }
        }
        /*
        Vector2 speedCap;
        speedCap.x = TopSpd;
        speedCap.y = fallSpeedCap;
        playerBody.velocity = Vector2.ClampMagnitude(playerBody.velocity, speedCap.y);

        if (Jump)
        {
            //forca base
            if (JumpStart)
            {
                playerBody.AddForce(new Vector2(0f, jumpForce));
                JumpStart = false;
            }
            //deceleració ràpida per contrarestar la força adicional
            playerBody.AddForce(new Vector2(0f, -2));
            if (JumpCount > 5)
            {
                Jump = false;z
            }
        }
        */

    }
}

//vector 4 spaces
//each second register position and put on last place, moving the three places one place ahead beforehand, discarding the oldest
//on press select the 
//cooldown de X seconds

