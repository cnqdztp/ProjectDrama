using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody player;

    float xVelocity;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        player.velocity = new Vector3(xVelocity * speed,0,0);
    }
}
