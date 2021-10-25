using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController3D characterController;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    private AudioSource Audio;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Audio = GetComponent<AudioSource> ();
        if (horizontalMove != 0)
        {
            if (!Audio.isPlaying)
            {
                Audio.Play ();
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
