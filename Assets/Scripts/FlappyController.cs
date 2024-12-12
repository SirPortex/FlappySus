using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class FlappyController : MonoBehaviour
{
    public float jumpForce, rotationSpeed;
    public Animator animator;
    public AudioClip jumpSound, hitSound;
    public Material flappyMaterial, outlineMaterial;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        flappyMaterial.color = Color.white;
        outlineMaterial.color = Color.black;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE //PARA QUE FUNCIONE EN PC
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.PlayAudio(jumpSound, "JumpSound", false, 0.08f);
            //AdDisplayManager.instance.ShowAd();
        }

#elif UNITY_ANDROID //PARA QUE FUNCIONE EN ANDROID

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                rb.velocity = Vector2.up * jumpForce;
                AudioManager.instance.PlayAudio(jumpSound, "JumpSound", false, 0.08f);
            }
        }
#endif
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * - rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pipe"))
        {
            flappyMaterial.color = Color.red;
            outlineMaterial.color = Color.white;
            AudioManager.instance.PlayAudio(hitSound, "HitSound", false, 0.08f);
            Debug.Log("Te chocaste");
            Destroy(this);
        }
    }
}
