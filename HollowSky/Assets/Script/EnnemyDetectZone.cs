using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyDetectZone : MonoBehaviour
{

    public GameObject corpsEnnemy;

    public float speed = 5;

    public Rigidbody rb;

    Vector3 dir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * dir.z + transform.up * dir.y + transform.right * dir.x;
        Vector3 velocity = move * speed;
        Vector3 rbVelocity = new Vector3(velocity.x, velocity.y, velocity.z);
        rb.velocity = rbVelocity;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            dir =  other.gameObject.transform.position - corpsEnnemy.transform.position;
            Debug.Log(dir);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            dir = Vector3.zero;
        }
    }

}
