using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBody : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<PlayerController>().TakeDamage(1);
        }
    }
}
