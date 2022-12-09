using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public NewBehaviourScript controller;
    bool jump = false;
    bool crouch = false;
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        { 
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch= false;   
        }
    
    
    }

    void FixedUpdate()
    {



        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;


    }
}