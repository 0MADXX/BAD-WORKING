using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialA : MonoBehaviour
{
    public Vector3 PickupPos;
    public Vector3 PickupRot;
    public Vector3 Pickupscale;

    public string Name
    {
        get
        {
            return "Material A";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
    
    public void OnPickup()
    {

    }
}
