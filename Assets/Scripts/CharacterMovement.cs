using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController3D characterController;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;

    public GameObject myBag;
    private bool isOpen;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        openMybag();
    }
    void FixedUpdate ()
    {
        // Move our character
        characterController.Move(horizontalMove * Time.fixedDeltaTime);
    }

    void openMybag()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOpen = !myBag.activeSelf;
            myBag.SetActive(isOpen);
        }
    }
}
