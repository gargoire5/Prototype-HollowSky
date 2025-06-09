using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public bool Activated = false;
    public static List<GameObject> CheckPointsList;
    public static Vector3 SpawnPoint;

    public static Vector3 GetActiveCheckPointPosition()
    {
        SpawnPoint = new Vector3();
        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                if (cp.GetComponent<Respawn>().Activated)
                {
                    SpawnPoint = cp.transform.position;
                    break;
                }
            }
        }
        return SpawnPoint;
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
        }
    }
}
