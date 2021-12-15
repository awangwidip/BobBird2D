using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePattern;
    public GameObject floatingHealth;

    private PlayerController playerController;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHealth", 10f, 10f);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePattern.Length);
            Instantiate(obstaclePattern[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

        if(playerController.health <= 0)
        {
            timeBtwSpawn = 10;
        }
    }

    private void SpawnHealth()
    {
        Instantiate(floatingHealth, transform.position, Quaternion.identity);
    }
}
