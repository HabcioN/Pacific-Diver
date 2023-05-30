using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    public NewBehaviourScript controller;
    bool jump = false;
    bool crouch = false;
    public float runSpeed = 60f;
    float horizontalMove = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        AnimationWalk();

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

    void AnimationWalk()
    {
        if (horizontalMove != 0)
        {
            anim.SetBool("walk", true);
        }
        else if (horizontalMove == 0)
        {
            anim.SetBool("walk", false);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            anim.Play("JumpAnimation");
        }

    }
}