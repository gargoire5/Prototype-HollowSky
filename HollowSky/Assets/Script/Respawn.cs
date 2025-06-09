using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool Activated = false;
    public static List<GameObject> CheckPointsList;

    public static Vector3 GetActiveCheckPointPosition()
    {
        Vector3 result = new Vector3(0, 1.77f, -21.44f);
        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                if (cp.GetComponent<Respawn>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }

    private void ActivateCheckPoint()
    {
        foreach(GameObject cp in CheckPointsList)
        {
            cp.GetComponent<Respawn>().Activated = false;
        }
        Activated = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint").ToList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ActivateCheckPoint();
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
