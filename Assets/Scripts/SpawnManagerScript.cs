using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemy;

    private DaylightNighttime dN;

    private float enemySpawnSpeed = 5.0f;
    public GameObject powerUpPrefab;

    private bool currentWave = false;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //InvokeRepeating("SpawnEnemy", 1.0f, 5.0f);

        dN = GameObject.Find("Directional Light").GetComponent<DaylightNighttime>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActive && (dN.cycle == 4 && !currentWave))
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

        if (gameManager.gameActive && dN.cycle == 4)
        {
            int spawnLocation = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnLocation].transform.position, spawnPoints[spawnLocation].transform.rotation);
        }
        else
        {
            CancelInvoke("SpawnEnemy");
            currentWave = false;
        }

    }
}
