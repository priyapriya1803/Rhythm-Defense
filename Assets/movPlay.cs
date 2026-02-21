using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlay : MonoBehaviour
{
    public float speed = 5f;
    //public Rigidbody rb;

   
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


}
