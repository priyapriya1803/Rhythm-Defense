using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform player;
    public float length = 30f;

    void Update()
    {
        
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        
        if (transform.position.z < player.position.z - length)
        {
           
            transform.position += new Vector3(0, 0, length * 2);
        }
    }

}
