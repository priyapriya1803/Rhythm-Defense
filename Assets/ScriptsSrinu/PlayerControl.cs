using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerAnimations playerAnim;
    public bool isLeftLegActive = false;
    public bool isRightLegActive = false;

    private void Start()
    {
        playerAnim = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        LegsMovement();
    }


    private void LegsMovement()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            isLeftLegActive = true;
            playerAnim.LeftLegUP();
            StartCoroutine(ResetLeftLeg());
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            isRightLegActive = true;
            playerAnim.RightLegUP();
            StartCoroutine(ResetRightLeg());
        }
    }


    IEnumerator ResetLeftLeg()
    {
        yield return new WaitForSeconds(0.2f);
        isLeftLegActive = false;
    }

    IEnumerator ResetRightLeg()
    {
        yield return new WaitForSeconds(0.2f);
        isRightLegActive = false;
    }

}
