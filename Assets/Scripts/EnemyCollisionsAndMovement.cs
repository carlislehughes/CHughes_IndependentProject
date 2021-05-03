using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionsAndMovement : MonoBehaviour
{
    public float speed = 30.0f;
    //private float deathBuffer = 3 * Time.deltaTime;  Attempting to buffer the destroy of the object so the death animation plays

    public GameObject[] doorPrefabs;
    public GameObject[] windowPrefabs;


    private Animator animEnemy;
    private AudioSource asEnemy;
    public AudioClip monsterGrunt;

    private SpawnManagerScript sMS;

    // Start is called before the first frame update
    void Start()
    {
        animEnemy = GetComponent<Animator>();
        asEnemy = GetComponent<AudioSource>();

        sMS = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sMS.gameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }



    void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;

        asEnemy.PlayOneShot(monsterGrunt, .4f);

        if ((collidedWith.CompareTag("Window")) || (collidedWith.CompareTag("W1")) || (collidedWith.CompareTag("W2")) || (collidedWith.CompareTag("RWindow")))
        {


            animEnemy.SetTrigger("Kick");
            DestroyWindows(collidedWith);
            StartCoroutine(EnemyDeathDelay());
            animEnemy.SetBool("Dead", true);



        }
        else if ((collidedWith.CompareTag("Door")) || (collidedWith.CompareTag("D1")) || (collidedWith.CompareTag("D2")) || (collidedWith.CompareTag("D3")) || (collidedWith.CompareTag("RDoor")))
        {

            animEnemy.SetTrigger("Kick");
            DestroyDoors(collidedWith);
            StartCoroutine(EnemyDeathDelay());
            animEnemy.SetBool("Dead", true);


        }
    }

    //Destory Windows that enemies collide with
    void DestroyWindows(GameObject window)
    {
        //OpenWindow
        if (window.CompareTag("Window"))
        {
            sMS.gameOver = true;
            Debug.Log("Game Over!");

            Destroy(window);
        }
        //1 Board Window
        else if (window.CompareTag("W1"))
        {
            Instantiate(windowPrefabs[0], window.transform.position, window.transform.rotation);
            Destroy(window);
        }
        //2 Board Window
        else if (window.CompareTag("W2"))
        {
            Instantiate(windowPrefabs[1], window.transform.position, window.transform.rotation);
            Destroy(window);
        }
        //3 Board Window - Full
        else if (window.CompareTag("RWindow"))
        {
            Instantiate(windowPrefabs[2], window.transform.position, window.transform.rotation);
            Destroy(window);
        }


    }

    //Destory Doors that enemies collide with
    void DestroyDoors(GameObject door)
    {

        //open door with no reinforce
        if (door.CompareTag("Door"))
        {
            Destroy(door);
            sMS.gameOver = true;
            Debug.Log("Game Over!");
        }
        //1 Reinforcement
        else if (door.CompareTag("D1"))
        {
            Instantiate(doorPrefabs[0], door.transform.position, door.transform.rotation);
            Destroy(door);
        }
        //2 Reinforcement
        else if (door.CompareTag("D2"))
        {
            Instantiate(doorPrefabs[1], door.transform.position, door.transform.rotation);
            Destroy(door);
        }
        //3 Reinforcement
        else if (door.CompareTag("D3"))
        {
            Instantiate(doorPrefabs[2], door.transform.position, door.transform.rotation);
            Destroy(door);
        }
        //4 Reinforcement -- full
        else if (door.CompareTag("RDoor"))
        {
            Instantiate(doorPrefabs[4], door.transform.position, door.transform.rotation);
            Destroy(door);
        }

    }

    IEnumerator EnemyDeathDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
