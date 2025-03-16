using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.81f * 2;
    [SerializeField] private float sprintSpeed = 2f;
    [SerializeField] private float jumpHeight = 3f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;

    private float sprintFactor = 1f;
    bool isGrounded;
    private bool isWalking;

    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        isWalking = move != Vector3.zero;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintFactor = sprintSpeed;
        }
        else
        {
            sprintFactor = 1;
        }

        controller.Move(move * speed * sprintFactor * Time.deltaTime);

        //Debug.Log(isGrounded);
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity) * 2;
        }

        velocity.y += gravity * Time.deltaTime * 5;

        controller.Move(velocity * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public float SprintFactor()
    {
        return sprintFactor;
    }
}