using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1f;
    [SerializeField] GameObject enemyPrefab;
 

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
        InvokeRepeating("SpawnEnemy", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float randY = Random.Range(yMin, yMax);
        Instantiate(enemyPrefab, new Vector3(xSpawn, randY, 0), Quaternion.identity);
    }
}
