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

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= GravityModifier;

        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !isGameOver)
        {
            playerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("F");
        }
    }
        
    
}

