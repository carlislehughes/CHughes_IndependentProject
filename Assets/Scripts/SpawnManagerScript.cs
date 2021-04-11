using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemy;

    public bool gameOver = false;

    private DaylightNighttime dN;
    // Start is called before the first frame update
    void Start()
    { 
        InvokeRepeating("SpawnEnemy", 1.0f, 5.0f);

        dN = GameObject.Find("Directional Light").GetComponent<DaylightNighttime>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    void SpawnEnemy()
    {
        if (!gameOver && (dN.cycle == 3)){
        int spawnLocation = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnLocation].transform.position, spawnPoints[spawnLocation].transform.rotation);
        }
    }
}
