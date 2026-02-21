using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTiling : MonoBehaviour
{
    Spwaning spwaning;

    private void Start()
    {
        spwaning = GameObject.FindObjectOfType<Spwaning>();
    }

    private void OnTriggerExit(Collider other)
    {

        spwaning.SpawnTile();
        Destroy(gameObject, 2);
    }
}
