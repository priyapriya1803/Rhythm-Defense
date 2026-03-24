using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovNew : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public float rotationSpeed = 300f;
    public AudioClip moveSound;

    private bool isRotating = false;
    private Quaternion targetRotation;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = moveSound;
        audioSource.loop = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            animator.SetTrigger("Walking");

        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0, -90f, 0);
            isRotating = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0, 90f, 0);
            isRotating = true;
        }

        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("Jump");

        if (Input.GetKeyDown(KeyCode.S))
            animator.SetTrigger("Slide");

        bool isMoving =
            Input.GetKey(KeyCode.W) ||
            isRotating;

        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }

        if (!Input.anyKey && !isRotating)
            animator.SetTrigger("Idle");
    }
}