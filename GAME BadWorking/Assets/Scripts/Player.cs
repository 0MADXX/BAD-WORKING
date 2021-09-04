using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    Vector3 forward;
    Vector3 right;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //initialize new forward and right vectors
        //by rotating the original ones by 45 degrees
        forward = Quaternion.Euler(new Vector3(0, 45, 0)) * transform.forward;
        right = Quaternion.Euler(new Vector3(0, 45, 0)) * transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 horizontalMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 verticalMovement = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        //rotate player
        transform.forward = Vector3.Normalize(horizontalMovement + verticalMovement);
        //move player
        transform.position += horizontalMovement + verticalMovement;
    }
}
