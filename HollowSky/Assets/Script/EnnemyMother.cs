using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMother : MonoBehaviour
{
    public float maxHeals = 1;
    public float heals;

    public bool isDead;

    public float timeRespawn;
    private float time;

    public virtual void Start()
    {
        heals = maxHeals;
    }

    public virtual void Update()
    {
        if (time >= timeRespawn)
        {
            this.Respawn();
        }
        time += Time.deltaTime;
    }

    public virtual void Dead()
    {
        time = 0;
    }

    public virtual void Respawn()
    {

    }

    public virtual void takeDamage(float damage)
    {
        heals -= damage;
        if (heals <= 0)
        {
            this.Dead();
        }
    }

}
