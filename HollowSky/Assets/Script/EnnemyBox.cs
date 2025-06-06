using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBox : EnnemyMother
{
    

    

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Respawn()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public override void Dead()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        base.Dead();
    }



    public override void takeDamage(float damage)
    {
        base.takeDamage(damage);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
            other.gameObject.GetComponent<PlayerController>().AtkZone.objects.Remove(this.gameObject);
            this.takeDamage(1);
        }
    }

}
