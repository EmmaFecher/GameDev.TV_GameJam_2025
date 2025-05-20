using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;
    public Rigidbody rb;
    public bool canControl = true;
    private Vector2 moveInput;
    public bool sprintInput;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if(canControl)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if(canControl)
        {
            if (context.started)
            {
                sprintInput = true;
            }
            else if (context.canceled)
            {
                sprintInput = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (sprintInput)
        {
            //sprinting
            rb.velocity = new Vector3(moveInput.x * (moveSpeed * sprintMultiplier), 0, moveInput.y * (moveSpeed * sprintMultiplier));
        }
        else
        {
            //not sprinting
            rb.velocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
        }
        
    }
}
