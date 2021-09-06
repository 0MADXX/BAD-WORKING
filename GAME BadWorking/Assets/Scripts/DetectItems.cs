using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItems : MonoBehaviour
{
    //Partly taken from youtube video:
    //https://www.youtube.com/watch?v=j1-OyLo77ss&ab_channel=Comp-3Interactive

    public float radius;
    //public GameObject itemRef;
    public LayerMask targetMask;
    public bool canDetectItem;

    private void Start()
    {
        //itemRef = GameObject.FindGameObjectWithTag("Item");
        StartCoroutine(DetectRoutine());
    }

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
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            //Transform target = rangeChecks[0].transform;
            canDetectItem = true;
        }
        else if (canDetectItem)
        {
            canDetectItem = false;
        }
    }
}