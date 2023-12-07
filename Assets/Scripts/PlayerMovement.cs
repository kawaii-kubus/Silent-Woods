using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public CharacterController controller;

    [Header("Ground")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    [Header("Speed")]
    public float speedWalking = 12f;
    public float speedRunning = 20f;
    Vector3 velocity;

    [Header("Jumping")]
    public float gravity = -9.81f;
    public float jumpHigh = 3f;

    void Update()
    {
        //Checking if IsGrounded 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
        //If is in the air add velocity to faster down
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        //Inputs x,y
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Moving 
        Vector3 move = transform.right * x + transform.forward * z;
        //Walking
        controller.Move(move * speedWalking * Time.deltaTime);
        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speedRunning * Time.deltaTime);

        }
        //Jumping from math formula
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHigh * -2f * gravity);
        }
        //Crouching
        if (Input.GetKey(KeyCode.C)) 
        {
            Vector3 newScale = new Vector3(1f, 0.5f, 1f);
            controller.transform.localScale = newScale;
        }
        else
        {
            Vector3 baseScale = new Vector3(1f, 1f, 1f);
            controller.transform.localScale = baseScale;
        }

        //Gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



    }
}
