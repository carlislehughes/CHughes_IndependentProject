﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemy;

    public bool gameOver = false;

    private DaylightNighttime dN;

    private float enemySpawnSpeed = 5.0f;
    public GameObject powerUpPrefab;

    private bool currentWave = false;
    // Start is called before the first frame update
    void Start()
    { 
        //InvokeRepeating("SpawnEnemy", 1.0f, 5.0f);

        dN = GameObject.Find("Directional Light").GetComponent<DaylightNighttime>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dN.cycle == 4  && !currentWave)
        {
            SpawnWave();
        }

    }

    void SpawnWave()
    {
        Instantiate(powerUpPrefab, powerUpPrefab.transform.position, powerUpPrefab.transform.rotation);
        InvokeRepeating("SpawnEnemy", 0.0f, enemySpawnSpeed);

        enemySpawnSpeed -= 1.0f;

        currentWave = true;
    }

    void SpawnEnemy()
    {
        if (!gameOver)
        {
        int spawnLocation = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnLocation].transform.position, spawnPoints[spawnLocation].transform.rotation);
        }
        else if (dN.cycle != 4)
        {
            CancelInvoke();
            currentWave = false;
        }
    }
}
