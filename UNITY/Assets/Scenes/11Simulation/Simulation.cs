using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    // ========================================================================================================
    // private variables
    // ========================================================================================================
    private int genNum;
    private int numOfCreatures = 100;

    private Creature[] creatureArray = new Creature[100];// create an array of type creature and length creatureNum

    private Creature bestCreature;
    private Creature secondBestCreature;
    private Creature currentCreature;// variable that will be used in functions
    private Creature currentBestCreature;// variable that will be used in functions

    public CameraFollow cameraFollowScript;
    public Transform    newTarget;
    private GameObject camera;

    // ========================================================================================================
    // Start is called before the first frame update
    // ========================================================================================================
    void Start()
    { 
        // Generation 0
        populateCreatureArray();
        
        setCamera(creatureArray[0]);
        // TEMPorarailly set the new target as the first creature in the array, for testing purposes
        bestCreature = getBestCreature();
    }

    // Update is called once per frame
    void Update()
    {   

        bestCreature = getBestCreature();

    }
    
    // ========================================================================================================
    // Getters and setters
    // ========================================================================================================

    void populateCreatureArray(){
        // this function is used at the Start() funciton
        for(int i = 0; i < numOfCreatures; i++){
        creatureArray[i] = new Creature();
        creatureArray[i].CreatureNoParent();
      }  
    }
    Creature getBestCreature(){
        currentBestCreature = creatureArray[0];
        Debug.Log(creatureArray[0].getCreatureBody());
        return (currentBestCreature);
    }

    void setCamera(Creature targetCreature){
        newTarget = targetCreature.getCreatureBody().transform;
        cameraFollowScript.setTarget(newTarget);
    }

    

}
