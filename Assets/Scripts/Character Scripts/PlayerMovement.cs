using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public GameUI ui;
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;
    public Rigidbody rb;
    public bool canControl = true;
    private Vector2 moveInput;
    private bool sprintInput;
    public bool fireInput;
<<<<<<< HEAD
    Animator anim;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
=======

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
>>>>>>> df5eac1441ec466b43e0a87789bb35971412ce49
    }

    public void Move(InputAction.CallbackContext context)
    {
<<<<<<< HEAD
        if (canControl)
        {
            moveInput = context.ReadValue<Vector2>();
            if (moveInput == Vector2.zero)
            {
                anim.SetBool("Moving", false);
            }
            else
            {
                anim.SetBool("Moving", true);
            }
=======
        if(canControl)
        {
            moveInput = context.ReadValue<Vector2>();
>>>>>>> df5eac1441ec466b43e0a87789bb35971412ce49
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
    public void Fire(InputAction.CallbackContext context)
    {
        if(canControl)
        {
            if (context.started)
            {
                fireInput = true;
            }
            else if (context.canceled)
            {
                fireInput = false;
            }
        }
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if(canControl)
        {
            if (context.canceled)
            {
                ui.PauseMenu();
            }
        }
    }
    private void FixedUpdate()
    {
        if (sprintInput)
        {
            //sprinting
            rb.velocity = new Vector3(moveInput.x * (moveSpeed * sprintMultiplier), 0, moveInput.y * (moveSpeed * sprintMultiplier));
            transform.rotation = Quaternion.LookRotation (new Vector3(moveInput.x * (moveSpeed * sprintMultiplier), 0, moveInput.y * (moveSpeed * sprintMultiplier))).normalized;
        }
        else
        {
            //not sprinting
            rb.velocity = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
            transform.rotation = Quaternion.LookRotation (new Vector3(moveInput.x * (moveSpeed * sprintMultiplier), 0, moveInput.y * (moveSpeed * sprintMultiplier))).normalized;
        }

    }
}
