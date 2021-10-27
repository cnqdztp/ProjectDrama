using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    [SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
    // [SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
    // [SerializeField] private Transform m_CeilingCheck;	
    // [SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching
    
    // const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    // private bool m_Grounded;            // Whether or not the player is grounded.
    // const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody m_Rigidbody;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 velocity = Vector3.zero;
    
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {   
        //####ignored jump function for lack of issue demanding###
        // m_Grounded = false;
        //
        // // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        // for (int i = 0; i < colliders.Length; i++)
        // {
        //     if (colliders[i].gameObject != gameObject)
        //         m_Grounded = true;
        // }
        //####ignored jump function for lack of issue demanding###
        // throw new NotImplementedException();
    }

    public void Move(float move)
    {
        //=== crouching is ignored for lack of issue demanding which===
        Vector3 targetVelocity = new Vector3(move * 10f, m_Rigidbody.velocity.y);
        m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
        
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            // Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            // Flip();
        }
    }
    
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    }
    

