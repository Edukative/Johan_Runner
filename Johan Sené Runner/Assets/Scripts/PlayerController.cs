using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;


    public float JumpForce;

    public float GravityModifier;




    bool IsOnGround = true;

    public bool isGameOver = false;

    private Animator playerAnim;

    public ParticleSystem explosion;
    public ParticleSystem dirt;
    private AudioSource playerAudio;

    public AudioClip explosionAudio;
    public AudioClip jumpAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= GravityModifier;

        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            dirt.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpAudio);
            
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            explosion.Play();
            Debug.Log("F");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(explosionAudio);
        }
    }
        
    
}

