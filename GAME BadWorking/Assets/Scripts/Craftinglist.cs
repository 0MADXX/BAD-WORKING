using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craftinglist : MonoBehaviour
{
    public Craft craft;

    public GameObject[] cloth;
    public GameObject[] strings;

    public GameObject[] finalProducts;

    bool taskDone;
    public int taskAmount;

    public bool result1;
    public bool result2;
    public bool result3;

    

    int index;

    
    private void Update()
    {
        

        if (craft.item[0] == cloth[0] && craft.item[1] == strings[0] && craft.canSpawn == true && craft.playerClose && Input.GetKeyDown(KeyCode.E))
        {
            craft.Spawn();
            Debug.Log("Result 1");
            
        }
        if (craft.item[index] == cloth[1] && craft.item[index] == strings[1])
        {
            result2 = true;
            Debug.Log("Result 2");
        }
        if (craft.item[index] == cloth[2] && craft.item[index] == strings[2])
        {
            result3 = true;
            Debug.Log("Result 3");
        } 
        
    }

}
