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
    private GameObject camera;

    // ========================================================================================================
    // Start is called before the first frame update
    // ========================================================================================================
    void Start()
    { 
        
        camera = GameObject.Find("MainCamera");
        Debug.Log(camera);
        cameraFollowScript = camera.GetComponent<CameraFollow>();
        // Generation 0
        for(int i = 0; i < numOfCreatures; i++){
            creatureArray[i] = new Creature();
            creatureArray[i].CreatureNoParent();
      }  
    }

    // Update is called once per frame
    void Update()
    {
        bestCreature = getBestCreature();
        cameraFollowScript.setTarget(bestCreature.getCreatureObject().transform);
        debug.Log(bestCreature);
        


    }
    
    private Creature getBestCreature(){// This method returns the creature in the lead  
        currentBestCreature = creatureArray[0];
        for(int i = 1; i < numOfCreatures; i++){
            currentCreature = creatureArray[i];
            if (currentCreature.getCreatureObject().transform.localPosition.x >= currentBestCreature.getCreatureObject().transform.localPosition.x){
                currentBestCreature = currentCreature;
            }
        }
        return bestCreature;
    }

    // ========================================================================================================
    // Getters and setters
    // ========================================================================================================


}
