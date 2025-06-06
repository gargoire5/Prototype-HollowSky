using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference MoveAction;
    public InputActionReference AttackAction;
    public InputActionReference DashAction;

    public float speed = 5f;

    public Rigidbody rb;
    public Transform playerCamera;

    private Vector2 inputDirection;

    public float attackRange = 1f;
    public float bounceForce = 10f;
    public LayerMask attackLayer;

    public AtkZone AtkZone;

    public float cooldownAtk;
    private float timeCooldown;

    bool isDash;

    public float dashForce = 10f;

    float lastDir;

    float timeDash = 0.5f;
    float timeD;

    void Start()
    {
        MoveAction.action.Enable();
        AttackAction.action.Enable();
        DashAction.action.Enable();
    }

    void Update()
    {
        inputDirection = MoveAction.action.ReadValue<Vector2>();

        if (AttackAction.action.IsPressed() && timeCooldown >= cooldownAtk)
        {
            DoDownAttack();
        }

        if(DashAction.action.IsPressed() && isDash)
        {
            Dash();
        }

        timeCooldown += Time.deltaTime;
        timeD += Time.deltaTime;
    }

    private void Dash()
    {
        if(lastDir > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.forward * dashForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            timeD = 0;
            isDash = false;
        } else if (lastDir < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.back * dashForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
            isDash = false;
            timeD = 0;
        }
    }
    

    private void DoDownAttack()
    {
        if (AtkZone.objects.Count > 0)
        {
            for (int i = 0; i < AtkZone.objects.Count; i++)
            {
                if (AtkZone.objects[i].layer == 7)
                {
                    AtkZone.objects[i].GetComponent<Ennemy>().Dead();
                    AtkZone.objects.Remove(AtkZone.objects[i]);
                    Debug.Log("destroy");
                }
                else
                {
                    Debug.Log("no destroy");                    
                }
            }
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            timeCooldown = 0;
            isDash = true;
        }
    }

    void FixedUpdate()
    {
        if(timeD >= timeDash)
        {
            MovePlayer();
        }
    }


    private void MovePlayer()
    {
        Vector3 move = transform.forward * inputDirection.x;
        Vector3 velocity = move * speed;
        Vector3 rbVelocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
        rb.velocity = rbVelocity;
        lastDir = inputDirection.x;
    }
    
}
