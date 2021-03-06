﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    private int materialCount;
    public GameObject[] doorPrefabs;
    public GameObject[] windowPrefabs;


    private AudioSource asPlayer;
    public AudioClip Hammersound;
    public ParticleSystem dustSystem;


    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        materialCount = 5;
        gameManager.UpdateMaterials(materialCount);

        asPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }


    void OnTriggerStay(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;

        //Check for Power UP
        if (collider.CompareTag("PowerUp"))
        {
            materialCount += 20;
            gameManager.UpdateMaterials(materialCount);
            Destroy(collidedWith);
        }

        if ((collidedWith.CompareTag("Window")) || (collidedWith.CompareTag("W1")) || (collidedWith.CompareTag("W2")))
        {

            gameManager.instructionsPopUp.SetActive(true);
            StartCoroutine(PopUpDelay());
            if (Input.GetKeyDown(KeyCode.E)) { ReinforceWindows(collidedWith); }
        }
        else if ((collidedWith.CompareTag("Door")) || (collidedWith.CompareTag("D1")) || (collidedWith.CompareTag("D2")) || (collidedWith.CompareTag("D3")))
        {
            gameManager.instructionsPopUp.SetActive(true);
            StartCoroutine(PopUpDelay());
            if (Input.GetKeyDown(KeyCode.E)) { ReinforceDoors(collidedWith); }
        }
        else
        {
            DestroyMaterialObjects(collidedWith);
        }
    }

    void DestroyMaterialObjects(GameObject other)
    {
        if (other.CompareTag("Table"))
        {
            //Add Material Count for Table
            float randMats = Random.Range(1, 6);
            materialCount += (int)randMats;

            gameManager.UpdateMaterials(materialCount);
            //Destory Table
            Destroy(other);
        }
        else if (other.CompareTag("LTable"))
        {
            //Add Material Count for Large Table
            float randMats = Random.Range(6, 15);
            materialCount += (int)randMats;

            gameManager.UpdateMaterials(materialCount);
            //Destory Large Table
            Destroy(other);
        }
        else if (other.CompareTag("Couch"))
        {
            //Add Material Count for Couch
            float randMats = Random.Range(10, 20);
            materialCount += (int)randMats;

            gameManager.UpdateMaterials(materialCount);
            //Destory Couch
            Destroy(other);
        }
        dustSystem.Play();
    }

    //Spend materials on collision with windows
    void ReinforceWindows(GameObject window)
    {
        if (materialCount > 0)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //open window with no reinforce
            if (window.CompareTag("Window"))
            {
                Instantiate(windowPrefabs[1], window.transform.position, window.transform.rotation);
                Destroy(window);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
            else if (window.CompareTag("W1"))
            {
                Instantiate(windowPrefabs[2], window.transform.position, window.transform.rotation);
                Destroy(window);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
            else if (window.CompareTag("W2"))
            {
                Instantiate(windowPrefabs[3], window.transform.position, window.transform.rotation);
                Destroy(window);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
        }

        asPlayer.PlayOneShot(Hammersound, .3f);
        dustSystem.Play();

    }

    //Spend materials on collision with doors
    void ReinforceDoors(GameObject door)
    {
        if (materialCount > 0)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //open door with no reinforce
            if (door.CompareTag("Door"))
            {
                Instantiate(doorPrefabs[1], door.transform.position, door.transform.rotation);
                Destroy(door);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
            else if (door.CompareTag("D1"))
            {
                Instantiate(doorPrefabs[2], door.transform.position, door.transform.rotation);
                Destroy(door);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
            else if (door.CompareTag("D2"))
            {
                Instantiate(doorPrefabs[3], door.transform.position, door.transform.rotation);
                Destroy(door);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
            else if (door.CompareTag("D3"))
            {
                Instantiate(doorPrefabs[4], door.transform.position, door.transform.rotation);
                Destroy(door);
                materialCount--;
                gameManager.UpdateMaterials(materialCount);
            }
        }
        asPlayer.PlayOneShot(Hammersound, .3f);
        dustSystem.Play();

    }

    IEnumerator PopUpDelay()
    {
        yield return new WaitForSeconds(1);
        gameManager.instructionsPopUp.SetActive(false);
    }
}
