using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference MoveAction;
    public InputActionReference AttackAction;

    public float speed = 5f;

    public Rigidbody rb;
    public Transform playerCamera;

    private Vector2 inputDirection;

    public float attackRange = 1f;
    public float bounceForce = 10f;
    public LayerMask attackLayer;
    private bool isAttackingDown = false;   

    void Start()
    {
        MoveAction.action.Enable();
        AttackAction.action.Enable();
    }

    void Update()
    {
        inputDirection = MoveAction.action.ReadValue<Vector2>();

        if (AttackAction.action.WasPressedThisFrame())
        {
            isAttackingDown = true; 
        }

        if (isAttackingDown)
        {
            DoDownAttack();
        }
    }

    private void DoDownAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, attackRange, attackLayer))
        {
            Debug.Log("Hit");
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
            }
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            isAttackingDown = false;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {
        Vector3 move = transform.forward * inputDirection.x + transform.right * inputDirection.y;
        Vector3 velocity = move * speed;
        Vector3 rbVelocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        rb.velocity = rbVelocity;
    }

}
