using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    private float repeatWith;
    void Start()
    {
        startPos = transform.position;
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x -repeatWith)
        {
            transform.position = startPos;
        }
    }
}
