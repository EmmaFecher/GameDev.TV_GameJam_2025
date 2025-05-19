using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;
public class PlayerMovement : MonoBehaviour
{
    public InputAction playerControls;
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector2 moveDirection = Vector2.zero;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        playerControls.Enable();
    }
    void OnDisable()
    {
        playerControls.Disable();
    }
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
    }
}
