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
        if(other.gameObject.tag == "Player")
        {
            spwaning.SpawnTile();
            Destroy(gameObject, 2);
        }
    }
}
