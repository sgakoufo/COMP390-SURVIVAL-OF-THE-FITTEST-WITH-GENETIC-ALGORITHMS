using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int numOfCreatures = 50;// Temp, this can change. probably to 100
        Creature[] creatureArray = new Creature[numOfCreatures]; // create array of type creature

        for(int i =0; i<numOfCreatures; i++){
            creatureArray[i] = Creature();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
