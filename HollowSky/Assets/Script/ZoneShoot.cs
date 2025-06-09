using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneShoot : MonoBehaviour
{

    public EnnemyShoot EnnemyShoot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            EnnemyShoot.isZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            EnnemyShoot.isZone = false;
        }
    }
}
