using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : EnnemyMother
{
    public float cooldownShoot;
    float cooldown;

    public GameObject prefabBall;

    Vector3 dir;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if(cooldown >= cooldownShoot && !isDead)
        {
            Shoot();
        }
        cooldown += Time.deltaTime;

        base.Update();
    }

    public override void Respawn()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;

        base.Respawn();
    }

    public override void Dead()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        base.Dead();
    }

    void Shoot()
    {
        cooldown = 0;
        dir = FindAnyObjectByType<PlayerController>().gameObject.transform.position - gameObject.transform.position;

        GameObject prefab = Instantiate(prefabBall);
        prefab.transform.position = this.gameObject.transform.position + dir * 0.2f;
        prefab.GetComponent<Ball>().dir = dir;
        Destroy(prefab, 3);
    }
    public override void takeDamage(float damage)
    {
        base.takeDamage(damage);
    }

}
