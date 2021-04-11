using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightNighttime : MonoBehaviour
{
    private int counter;
    public int cycle;
    Light sun;

    public float DayLength;
    private float rSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light>();
        cycle = 1;
        InvokeRepeating("Timer", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rSpeed = Time.deltaTime / DayLength;
        transform.Rotate(0, rSpeed, 0);

        //sun not leaking through floor
        //if ( transform.rotation.y < 180) { }
    }

    /**
     * A Timer that changes the lighting based on the current play time in the game.
     * Light intensity goes 1 - 0.5 - 0 - 0.5 - 1 etc.
     * (Later will be used to implement Day Counter)
     */
    void Timer()
    {
        counter++;

        if (counter > 23)
        {
            counter = 0;
            switch (cycle)
            {
                case 1:
                    sun.intensity = 0.5f;
                    break;
                case 2:
                    sun.intensity = 0.0f;
                    break;
                case 3:
                    sun.intensity = 0.5f;
                    break;
                case 4:
                    sun.intensity = 1.0f;
                    break;
                default:
                    sun.intensity = 1.0f;
                    break;
            }
            cycle++;
            counter = 0;
        }
        if (cycle > 4) 
        { 
            cycle = 1; 
        }
        Debug.Log("counter: " + counter); 
        Debug.Log("cycle: " + cycle);


    }
}
