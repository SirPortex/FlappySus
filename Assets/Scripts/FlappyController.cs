using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour
{
    public float jumpForce;
    public Animator animator;

    private Rigidbody rb;
    private bool jumpPressed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
            //jump
        }
    }

    private void FixedUpdate()
    {
        ApplyJumpSpeed();
    }

    void ApplyJumpSpeed()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
            jumpPressed = false;
        }
    }
}
