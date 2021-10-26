using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController3D characterController;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    private AudioSource Audio;
    private Animator animator;

    private void Awake()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        animator = transform.GetChild(2).gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("AbsRawSpeed",Math.Abs(horizontalMove));
        if (horizontalMove != 0)
        {
            
            if (!Audio.isPlaying)
            {
                Audio.Play();
            }
        }
        else
        {
            Audio.Stop();
        }
    }
    void FixedUpdate ()
    {
        // Move our character
        characterController.Move(horizontalMove * Time.fixedDeltaTime);
    }
    
    
    
}
