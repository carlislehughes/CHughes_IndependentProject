using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Input
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs each frame
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //movement - forward
        transform.Translate(Vector3.forward * Time.deltaTime * 1.0f * verticalInput);
        //movement - turning
        transform.Translate(Vector3.forward * Time.deltaTime * 3.0f * horizontalInput);
    }
}
