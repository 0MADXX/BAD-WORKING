using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public float radius;
    public Transform playerDistance;
    public float usageRadius;

    public bool canDetectItem;
    public bool playerClose;
    public bool canSpawn;

    public GameObject[] item;
    public Craftinglist list;

    public LayerMask targetMask;
    public GameObject CraftMessage;
    private GameObject target;
    private Rigidbody targetRb;
    private Collider targetCol;
    public bool sitonTable = false;
    public bool despawnobject = false;

    [SerializeField] private Transform slot1;
    [SerializeField] private Transform slot2;
    [SerializeField] private Transform slot3;

    

    

    // Start is called before the first frame update
    void Start()
    {
        
        item = new GameObject[2];
        StartCoroutine(DetectRoutine());

    }

    public bool slot1Full()
    {
        
        if (slot1.childCount == 1) return true;
        else return false;
        
    }

    public bool slot2Full()
    {
        
        if (slot2.childCount == 1) return true;
        else return false;
    }

    public void Update()
    {

        Vector3 distanceToPlayer = playerDistance.position - transform.position;
        if (distanceToPlayer.magnitude <= usageRadius)
        {
            playerClose = true;
        } else
        {
            playerClose = false;
        }
        

        if (Input.GetKeyDown(KeyCode.R) && target != null)
        {
            

            if (!slot1Full())
            {
                putObjectOnTable(slot1);
                item[0] = GameObject.FindGameObjectWithTag("Item");
                item[1].gameObject.tag = "Untagged";
            }
            else if (!slot2Full())
            {
                item[0].gameObject.tag = "Untagged";
                putObjectOnTable(slot2);
                item[1] = GameObject.FindGameObjectWithTag("Item");
                
            }
            else Debug.Log("Can't put object on table, both slots are full already");
        }

        else if (Input.GetKeyDown(KeyCode.E) && slot1Full() && slot2Full() && playerClose)
        {

            //item[0].SetActive(false);
            //item[1].SetActive(false);
            slot1.DetachChildren();
            slot2.DetachChildren();
            Destroy(item[0]);
            Destroy(item[1]);
            item[0] = null;
            item[1] = null;
            canSpawn = false;
 
        }

        if (slot1Full() && slot2Full() && playerClose)
        {
            CraftMessage.SetActive(true);
        } else
        {
            CraftMessage.SetActive(false);
        }

        
    }

    public void Spawn()
    {
        Instantiate(list.finalProducts[2], new Vector3(3, 2.5f, 0), Quaternion.identity);
    }

    //coroutine that only checks for objects every 0.2 seconds, to save performance
    private IEnumerator DetectRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            DetectItemsCheck();
        }
    }

    private void DetectItemsCheck()
    {
        if (slot1Full() && slot2Full()) {
            canSpawn = true;
            return; 
        }

        //list of targets within range
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //if lenght of list is not zero, one or more items are detected
        if (rangeChecks.Length != 0)
        {
            //target is set as first item on list
            //TODO: should be closest item??
            //or just don't put items close together

            target = rangeChecks[0].gameObject;

            targetRb = target.GetComponent<Rigidbody>();
            targetCol = target.GetComponent<Collider>();

            canDetectItem = true;
        }
        else if (canDetectItem)
        {
            canDetectItem = false;
            target = null;
        }
    }

    private void putObjectOnTable(Transform slot)
    {
        Debug.Log("Put object on table on "+slot.name);

        

        targetRb.isKinematic = true;
        targetCol.isTrigger = true;

        target.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        target.transform.SetParent(slot);
        target.transform.SetPositionAndRotation(slot.position, Quaternion.identity);

        target.layer = 0;
        target = null;
    }
}
