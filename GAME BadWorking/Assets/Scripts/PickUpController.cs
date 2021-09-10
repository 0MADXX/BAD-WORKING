using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{

    public MaterialA material;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, materialContainer, camera;
    public Transform workTable, workTableContainer;

    public float pickUpRange;
    public float dropRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;


    private void Start()
    {
        if (!equipped)
        {
            material.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            material.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (distanceToPlayer.magnitude <= pickUpRange && !slotFull && !equipped)
            {
                PickUp();
            }
            else if (slotFull)
            {
                Drop();
            }
        }

        /*
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
        }

        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
        */

    }
    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        transform.SetParent(materialContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;

        material.enabled = true;
    }

    private void Drop()
    {
        Vector3 distanceToWorkTable = player.position - workTable.transform.position;


        if (distanceToWorkTable.magnitude <= dropRange)
        {
            putOnWorkingTable();
            equipped = true;
        }
        else
        {
            dropOnFloor();
            equipped = false;
        }

        
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        material.enabled = false;
    }

    private void putOnWorkingTable()
    {
        //make worktable parent of object
        transform.SetParent(workTableContainer);


        if (workTableContainer.childCount == 1)
        {
            transform.localPosition = new Vector3(3, 2.5f, 0.6f);
        }
        else transform.localPosition = new Vector3(3, 2.5f, -0.6f);

        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    private void dropOnFloor()
    {
        float yOffset = transform.localScale.y;

        if (transform.parent != null)
        {
            transform.position = transform.parent.position + transform.parent.forward - new Vector3(0, yOffset, 0);
        }

        //make it an orphan
        transform.SetParent(null);

        /*
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(camera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(camera.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
        */

    }


}
