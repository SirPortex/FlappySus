using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour
{
    public float jumpForce, rotationSpeed;
    public Animator animator;
    public AudioClip jumpSound, hitSound;

    private Rigidbody rb;

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
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.PlayAudio(jumpSound, "JumpSound", false, 0.08f);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * - rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pipe"))
        {
            AudioManager.instance.PlayAudio(hitSound, "HitSound", false, 0.08f);
            Debug.Log("Te chocaste");
            Destroy(this);
        }
    }
}
