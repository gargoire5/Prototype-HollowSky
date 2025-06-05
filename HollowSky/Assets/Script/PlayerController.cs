using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference MoveAction;
    public InputActionReference JumpAction;

    public float speed = 5f;

    public Rigidbody rb;
    public Transform playerCamera;

    private Vector2 inputDirection;



    void Start()
    {
        MoveAction.action.Enable();
        JumpAction.action.Enable();
    }

    void Update()
    {
        inputDirection = MoveAction.action.ReadValue<Vector2>();

        //RotateView();

        if (JumpAction.action.WasPressedThisFrame())
        {
            //atk
        }
    }

    void FixedUpdate()
    {
            MovePlayer();
    }

    private void MovePlayer()
    {
        Debug.Log("oui");
        Vector3 move = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        Vector3 velocity = move * speed;
        Vector3 rbVelocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        rb.velocity = rbVelocity;
    }

}
