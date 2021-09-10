using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool detectable = true;
    public Craft craft;
    public InteractWithItems items;
   
    [SerializeField] private Transform craftingTable;


    public void Start()
    {
        items = FindObjectOfType<InteractWithItems>();
        craft = FindObjectOfType<Craft>();
       
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, craftingTable.position);

        if (distance <= items.tableRadius)
        {
            gameObject.tag = "Item";
        } else if (distance > items.tableRadius)
        {
            gameObject.tag = "Untagged";
        }
        
    }


}
