using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    public float groundMovementSpeed = 10f;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * groundMovementSpeed * Time.deltaTime);
    }
}
