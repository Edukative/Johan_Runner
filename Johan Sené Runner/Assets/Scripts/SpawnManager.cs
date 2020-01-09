using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public int obsIndex;
    public GameObject ObstaclePrefab;
    private Vector3 Spawpos = new Vector3(25, 0.5f, 0);

    private float StartDelay = 2;
    private float RepeatRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);    
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObstacle ()
    {
        int obsIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obsIndex], Spawpos,
            obstacles[obsIndex].transform.rotation);
    }
}
