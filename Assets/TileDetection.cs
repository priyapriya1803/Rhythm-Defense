using UnityEngine;

public class TileDetection : MonoBehaviour
{
    private PlayerControl playerControl;


    private void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Leg") && playerControl.isLeftLegActive)
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Right Leg") && playerControl.isRightLegActive)
        {
            Destroy(gameObject);
        }
    }
}
