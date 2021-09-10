using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject Hand;

    public float speed = 5f;
    Vector3 forward;
    Vector3 right;

    Vector3 vertical;
    Vector3 horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        forward = transform.forward;
        right = transform.right;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            vertical = Input.GetAxis("Vertical") * forward;
            horizontal = Input.GetAxis("Horizontal") * right;

            //rotate player
            transform.forward = Vector3.Normalize(horizontal + vertical);

            //move player
            rb.velocity = transform.forward * speed;
        }
        else rb.velocity = new Vector3();
    }

   
}
