using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public int obsIndex;
    public GameObject ObstaclePrefab;
    private Vector3 Spawpos = new Vector3(34, 0, 0);

    private float StartDelay = 2;
    private float RepeatRate = 1;

    public float repeatRateMin = 1;
    public float repeatRateMax = 3;


    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Invoke("SpawnObstacle", (Random.Range(repeatRateMin, repeatRateMax)));
    }
    void Update()
    {
        if (Invoke("SpawnObstacle"; (Random.Range(repeatRateMin, repeatRateMax)
    }

    void SpawnObstacle ()
    {
        if (!playerControllerScript.isGameOver)
        {
            int obsIndex = Random.Range(0, obstacles.Length);
            Instantiate(obstacles [obsIndex], Spawpos, obstacles[obsIndex].transform.rotation);

            float randomDelay = Random.Range(repeatRateMin, repeatRateMax);
            Debug.Log("It's actually working" + randomDelay);
            Invoke("SpawnObstacle", randomDelay);
        }
      
    }
}
