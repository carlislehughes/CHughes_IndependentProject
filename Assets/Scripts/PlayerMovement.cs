using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Input
    private float verticalInput;
    private float horizontalInput;
    //private float mHInput;
    //private float mVInput;


    private SpawnManagerScript sMS;

    // Start is called before the first frame update
    void Start()
    {

        sMS = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sMS.gameOver)
        {
            //Get inputs each frame - WASD
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            //Mouse Inputs
            //mHInput = 2.0f * Input.GetAxis("Mouse X");
            //mVInput = 2.0f * Input.GetAxis("Mouse Y");

            //movement - forward
            transform.Translate(Vector3.forward * Time.deltaTime * 7.0f * verticalInput);
            //movement - turning
            transform.Rotate(Vector3.up, Time.deltaTime * 100.0f * horizontalInput);


            //Later updating to turn and look based off of mouse input
            //transform.Rotate(mVInput, mHInput, 0);
        }
    }
}
