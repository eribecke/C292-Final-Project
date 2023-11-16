using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1f;
    [SerializeField] GameObject enemyPrefab;
    float timer = 3;
 

    float yMin;
    float yMax;
    float xSpawn;

    void FixedUpdate()
    {
        yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, .1f, 0)).y;
        yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, .9f, 0)).y;
        xSpawn = Camera.main.ViewportToWorldPoint(new Vector3(1.25f, 0, 0)).x;

    
    }
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; }


        if (timer < 0)
        {
            InvokeRepeating("SpawnEnemy", 0, spawnRate);
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        float randY = Random.Range(yMin, yMax);
        Instantiate(enemyPrefab, new Vector3(xSpawn, randY, 0), Quaternion.identity);
    }
}
