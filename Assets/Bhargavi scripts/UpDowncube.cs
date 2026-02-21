using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDowncube : MonoBehaviour
{
    public float jumpForce = 1f;
    public float maxHeight = 15f;
    public bool isTriggered = false;
    // private Rigidbody rb;
    // // Start is called before the first frame update
    // void Start()
    // {
    //      rb = GetComponent<Rigidbody>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //      if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         if (rb != null)
    //         {
    //             rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    //         }
        
    //     }
    // }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTriggered = true;
        }
        if (isTriggered)
        {
            if(transform.position.y <= maxHeight)
            {
                transform.Translate(0, jumpForce * Time.deltaTime, 0);
            }
            
        }
    }
}
