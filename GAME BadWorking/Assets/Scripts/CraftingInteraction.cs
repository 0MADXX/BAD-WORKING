using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingInteraction : MonoBehaviour
{

    public GameObject material1;
    public GameObject material2;
    public GameObject material3;
    

    public Transform player, item1, item2, workTableContainer;

    public float usageRange;
    public float destroyRange;

    Vector3 distanceToItem1;
    Vector3 distanceToItem2;

    private void Start()
    {
  
    }

    private void Update()
    {

        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude <= usageRange && workTableContainer.childCount == 2 && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("childCount: " + workTableContainer.childCount);
            Debug.Log("child 0: " + workTableContainer.GetChild(0).name);
            Debug.Log("child 1: " + workTableContainer.GetChild(1).name);
            Debug.Log("DEATH");
            Destroy(material1);
            Destroy(material2);
            Spawn();
        }

        /*
        if (item1 != null)
        {
            distanceToItem1 = item1.position - transform.position;
        }

        if (item2 != null)
        {
            distanceToItem2 = item2.position - transform.position;
        }

        if (item1 != null && item2 != null)
        {
            if (distanceToPlayer.magnitude <= usageRange && workTableContainer.childCount == 2 && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("DEATH");
                Destroy(material1);
                Destroy(material2);
                Spawn();
            }
        }
        */

    }

    private void Spawn()
    {
        Instantiate(material3, new Vector3(3, 2.5f, 0), Quaternion.identity);
    }
}
