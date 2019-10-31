using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed;

    private PlayerController PlayerControllerScript;

    private float leftBound = -15;

     void Start()
     {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();  
     }
    // Update is called once per frame
    void Update()
    {
        if (!PlayerControllerScript.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);  
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }   
}
