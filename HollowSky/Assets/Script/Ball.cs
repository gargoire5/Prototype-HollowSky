using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 dir;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * dir.z + transform.up * dir.y + transform.right * dir.x;
        Vector3 velocity = move * speed;
        Vector3 rbVelocity = new Vector3(velocity.x, velocity.y, velocity.z);
        rb.velocity = rbVelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            other.GetComponent<PlayerController>().TakeDamage(2);
        }
            Destroy(this.gameObject);
    }
}
