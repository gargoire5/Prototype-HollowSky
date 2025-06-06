using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyDetectZone : EnnemyMother
{

    public GameObject EnnemyBody;

    public float speed = 5;

    public Rigidbody rb;

    Vector3 dir;

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if(!isDead) 
        {
            Vector3 move = transform.forward * dir.z + transform.up * dir.y + transform.right * dir.x;
            Vector3 velocity = move * speed;
            Vector3 rbVelocity = new Vector3(velocity.x, velocity.y, velocity.z);
            rb.velocity = rbVelocity;
        }

        base.Update();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            dir =  other.gameObject.transform.position - EnnemyBody.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            dir = Vector3.zero;
        }
    }

    public override void Dead()
    {
        dir = Vector3.zero;
        EnnemyBody.transform.localPosition = Vector3.zero;
        EnnemyBody.SetActive(false);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        base.Dead();
    }

    public override void Respawn()
    {
        EnnemyBody.SetActive(true);
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        base.Respawn();
    }

    public override void takeDamage(float damage)
    {
        base.takeDamage(damage);
    }



}
