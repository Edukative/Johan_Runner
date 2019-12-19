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
    public bool restart = false;

    private Animator playerAnim;

    public ParticleSystem explosion;
    public ParticleSystem dirt;
    private AudioSource playerAudio;

    public AudioClip explosionAudio;
    public AudioClip jumpAudio;

    public int hp;

    private SpriteRenderer hp1;
    private SpriteRenderer hp2;
    private SpriteRenderer hp3;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= GravityModifier;

        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

        GameObject canvas = GameObject.Find("Canvas");
        hp1 = canvas.transform.GetChild(0).GetComponent<SpriteRenderer>();
        hp2 = canvas.transform.GetChild(1).GetComponent<SpriteRenderer>();
        hp3 = canvas.transform.GetChild(2).GetComponent<SpriteRenderer>();
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
        else if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            isGameOver = false;
            hp = 4;
            loseHp();
            restart = true;
            playerAnim.SetBool("Death_b", false);
        }
    }   
    void loseHp()
    {
        if (hp >= 0)
        {
            hp--;
            switch (hp)
            {
                case 2: hp3.gameObject.SetActive(false);
                    break;
                case 1: hp2.gameObject.SetActive(false);
                    break;
                case 0: hp1.gameObject.SetActive(false);
                    isGameOver = true;

                    playerAnim.SetBool("Death_b", true);
                    playerAnim.SetInteger("DeathType_int", 1);

                    explosion.Play();
                    dirt.Stop();
                    playerAudio.PlayOneShot(explosionAudio);

                    break;
                default: hp3.gameObject.SetActive(true);
                         hp2.gameObject.SetActive(true);
                         hp1.gameObject.SetActive(true);
                    break;

            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            loseHp();
            Destroy(collision.gameObject);
        }
    }     
}

