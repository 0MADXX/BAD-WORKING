using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithItems : MonoBehaviour
{
    //Partly taken from youtube video:
    //https://www.youtube.com/watch?v=j1-OyLo77ss&ab_channel=Comp-3Interactive

    public float radius;
    public float tableRadius;
    public LayerMask targetMask;

    public GameObject Message;
    public GameObject TableMessage;

    [SerializeField] private Transform slot;
    private GameObject target;
    private Rigidbody targetRb;
    private Collider targetCol;

    [SerializeField] private Transform craftingTable;

    public bool slotFull;
    public bool canDetectItem;

    

    private void Start()
    {
        StartCoroutine(DetectRoutine());
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, craftingTable.position);
        Message.SetActive(canDetectItem);

        if (target != null)
        {
            if (target.layer == 0)
            {
                target = null;
            }
        }

        if (distance < tableRadius && slotFull)
        {
            TableMessage.SetActive(true);
        } else
        {
            TableMessage.SetActive(false);
        }
        

        //interact
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (slotFull)
            {
                drop();
                slotFull = false;
            }
            else if (!slotFull && target != null)
            {
                pickUp();
                canDetectItem = false;
                slotFull = true;
            }
            else Debug.Log("Tried to pick up, but target == null");
        }
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
        if (slotFull) return;

        //list of targets within range
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //if length of list is not zero, one or more items are detected
        if (rangeChecks.Length != 0)
        {
            canDetectItem = true;

            //target is set as first item on list
            //TODO: should be closest item??
            //or just don't put items close together
            target = rangeChecks[0].gameObject;
            targetRb = target.GetComponent<Rigidbody>();
            targetCol = target.GetComponent<Collider>();
        }
        else if (canDetectItem)
        {
            canDetectItem = false;
            target = null;
        }
    }

    private void pickUp()
    {
        Debug.Log("Pick up");

        slotFull = true;

        targetRb.isKinematic = true;
        targetCol.isTrigger = true;

        target.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        target.transform.SetParent(slot);
        target.transform.SetPositionAndRotation(slot.position, Quaternion.identity);
    }

    private void drop()
    {
        //drop on floor
        //only drop on floor when there is no crafting table nearby

        if (target == null) return;
        if (target.layer == 0) return;


        float distance = Vector3.Distance(transform.position, craftingTable.position);
        if (distance > tableRadius)
        {
            Debug.Log("Drop on floor");

            slotFull = false;

            targetRb.isKinematic = false;
            targetCol.isTrigger = false;

            target.transform.SetParent(null);
            target.transform.SetPositionAndRotation(transform.position + transform.forward * 2, Quaternion.identity);
            target.transform.localScale = Vector3.one;

        }

        else if (distance < tableRadius)
        {
            Debug.Log("place on table");
            slotFull = false;

            targetRb.isKinematic = false;
            targetCol.isTrigger = false;

            canDetectItem = false;

            target.transform.SetParent(null);
            target.transform.SetPositionAndRotation(transform.position + transform.forward * 2, Quaternion.identity);
            target.transform.localScale = Vector3.one;

        } 
        




    }





}
