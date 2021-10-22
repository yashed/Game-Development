﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables 
    public Rigidbody Rb;
    public Animator anim;

    //Float variables to player controll
    public float speed;
    public float JumpSpeed;
    float VarVal;

    //Bool variables for the player animation management
    bool Jump;
    bool Run;
    bool Climb;



    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Assing Verical value to the VarVal
        VarVal = Input.GetAxisRaw("Vertical");


        //Player Run
        if (VarVal > 0.1 && Climb == false && Run == true)
        {
            Debug.Log("VarVal 1");
            transform.position += Vector3.forward * Time.deltaTime * speed;

        }

        //Player Climb
        else if (VarVal > 0.1 && Climb == true)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        //Player Jump
        else if (VarVal > 0.1 && Jump == true)
        {
            Debug.Log("jemp speed");
            transform.position += Vector3.forward * Time.deltaTime * JumpSpeed;
        }


        //Set Animator Parameters to the variables
        anim.SetFloat("Run", VarVal);
        anim.SetBool("jump", Jump);
        anim.SetBool("climb", Climb);
    }


    private void OnTriggerEnter(Collider Coll)
    {

        if (Coll.tag == "Jump")
        {
            Debug.Log("jump");
            Jump = true;
            Run = false;
            Climb = false;
        }

        if (Coll.tag == "Ground")
        {
            Debug.Log("jump false");
            Jump = false;
            Run = true;
            Climb = false;
        }

        if (Coll.tag == "Climb")
        {
            Climb = true;
        }

       

        
    }
}