using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightNighttime : MonoBehaviour
{
    private int counter;
    public int cycle = 0;
    Light sun;

    public float DayLength;
    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light>();
        InvokeRepeating("Timer", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
     * A Timer that changes the lighting based on the current play time in the game.
     * Light intensity goes 1 - 0.5 - 0 - 0.5 - 1 etc.
     * (Later will be used to implement Day Counter)
     */
    void Timer()
    {



        counter++;

        if (counter > DayLength)
        {
            counter = 0;
            cycle++;
            switch (cycle)
            {
                case 1:
                    Debug.Log("case: 1, cycle" + cycle);
                    sun.intensity = 0.5f;
                    transform.Rotate(90f, 0.0f, 0.0f);
                    //set sun rotation to morning
                    break;
                case 2:
                    Debug.Log("case: 2, cycle" + cycle);
                    sun.intensity = 1.0f;
                    transform.Rotate(90f, 0.0f, 0.0f);
                    //set sun rotation to noon
                    break;
                case 3:
                    Debug.Log("case: 3, cycle" + cycle);
                    sun.intensity = 0.5f;
                    transform.Rotate(90f, 0.0f, 0.0f);
                    //set sun rotation to afternoon
                    break;
                case 4:
                    Debug.Log("case: 4, cycle" + cycle);
                    sun.intensity = 0.0f;
                    transform.Rotate(90f, 0.0f, 0.0f);
                    //set sun rotation to night
                    break;
                default:
                    sun.intensity = 1.0f;
                    transform.Rotate(0f, 0.0f, 0.0f);
                    break;
            }
            
        }
        if (cycle > 4) 
        { 
            cycle = 0; 
        }
        //Debug.Log("counter: " + counter); 
        //Debug.Log("cycle: " + cycle);


    }
}
