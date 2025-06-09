using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkZone : MonoBehaviour
{

    public List<GameObject> objects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        objects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        objects.Remove(other.gameObject);
    }

}
