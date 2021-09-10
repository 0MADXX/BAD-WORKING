using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRIDARRANGE : MonoBehaviour
{
    public float x_Start, z_Start;
    public int ColumnLength;
    public int RowLength;
    public int x_Space, z_Space;
    public GameObject prefab;

    void Start()
    {
        for (int i = 0; i < ColumnLength + RowLength; i++)
        {
            Vector3 rotationVector = new Vector3(0,-90, 0);
            Quaternion rotation = Quaternion.Euler(rotationVector);
            Vector3 position;
            position = new Vector3(x_Start + (x_Space * (i % ColumnLength)), 0 ,z_Start + (-z_Space * (i / ColumnLength)));
            Instantiate(prefab, position, rotation);
            
        }

    }
}