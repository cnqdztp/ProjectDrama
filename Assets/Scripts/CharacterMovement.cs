using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController3D characterController;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

    }
    void FixedUpdate ()
    {
        // Move our character
        characterController.Move(horizontalMove * Time.fixedDeltaTime);
    }
    
    
    
}
