using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
    private int materialCount;
    // Start is called before the first frame update
    void Start()
    {
        materialCount = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
       GameObject collidedWith = collider.gameObject;

        if (collidedWith.tag == "Window")
        {
            ReinforceWindows(collidedWith);
        }
        else if (collidedWith.tag == "Door")
        {
            ReinforceDoors(collidedWith);
        }
        else
        {
            DestroyMaterialObjects(collidedWith);
        }
    }

    void DestroyMaterialObjects(GameObject other)
    {
        if (other.tag == "Table")
        {
            //Add Material Count for Table
            float randMats = Random.Range(1, 6);
            materialCount += (int) randMats;

            //Destory Table
            Destroy(other);
        }
        else if (other.tag == "LTable")
        {
            //Add Material Count for Large Table
            float randMats = Random.Range(6, 15);
            materialCount += (int) randMats;

            //Destory Large Table
            Destroy(other);
        }
        else if (other.tag == "Couch")
        {
            //Add Material Count for Couch
            float randMats = Random.Range(10, 20);
            materialCount += (int) randMats;

            //Destory Couch
            Destroy(other);
        }
    }

    //Spend materials on collision with windows
    void ReinforceWindows(GameObject window)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            materialCount -= 3;
            //Replace Window tag with RWindow tag
            window.tag = "RWindow";
            //Replace OpenDoor prefab with Door prefab
        }
    }

    //Spend materials on collision with doors
    void ReinforceDoors(GameObject door)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            materialCount -= 4;
            //Replace Door tag with RDoor tag
            door.tag = "RDoor";
            //Replace OpenDoor prefab with Door prefab
        }
    }
}