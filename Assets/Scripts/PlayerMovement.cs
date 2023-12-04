using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speedWalking = 12f;
    public float speedRunning = 100f;
    public float gravity = -9.81f;
    public float jumpHigh = 3f;

    bool isGrounded;
    Vector3 velocity;
    void Update()
    {
        //Cheking if IsGrounded 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Checing if its not in air
        if(isGrounded && velocity.y < 0)
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
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speedRunning * Time.deltaTime);

        }
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHigh * -2f * gravity);
        }
        //Gravity 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



    }
}
