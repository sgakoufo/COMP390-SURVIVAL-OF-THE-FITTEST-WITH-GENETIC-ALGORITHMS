using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript: MonoBehaviour
{
    private float timeElapsed;
    //This class will be used to measure the time elapsed in a simulation
    void Start(){
        timeElapsed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        // time constantly updated
        timeElapsed += Time.deltaTime;
        //Debug.Log("Time elapsed: " + System.Math.Round(timeElapsed, 2));
        // uncomment if needed for testing purposes
    }

    public float getTime(){
        return timeElapsed;
    }
}
