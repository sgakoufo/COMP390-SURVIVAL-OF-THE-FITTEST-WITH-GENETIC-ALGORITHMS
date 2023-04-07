// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Simulation : MonoBehaviour
// {
//     // ========================================================================================================
//     // private variables
//     // ========================================================================================================
//     private int genNum;
//     private int numOfCreatures = 100;
//     private int numOfMutations = 0;
//     private Color generationColor;

//     private Creature[] creatureArray = new Creature[100];// create an array of type creature and length creatureNum

//     DontDestroy dontDestroyScript;

//     private Creature bestCreature;
//     private Creature secondBestCreature;
//     private Creature currentCreature;// variable that will be used in functions
//     private Creature currentBestCreature;// variable that will be used in functions
//     private Creature currentSecondBestCreature;// variable that will be used in functions



//     public CameraFollow cameraFollowScript;
//     public Transform    newTarget;
//     private GameObject camera;

//     private float timeElapsed;
//     TimeScript timeScript;

//     SceneRestart sceneRestartScript;

    

//     // ========================================================================================================
//     // Start is called before the first frame update
//     // ========================================================================================================
//     void Start()
//     { 
//         dontDestroyScript = GameObject.Find("DontDestroy").GetComponent<DontDestroy>();
//         generationColor = Random.ColorHSV();// randomly generate a generaiton color. This will be passed to the creatures
//         // each geneartion has a color so its easily distinguible which creatures are from a previous or new generation


//         if (dontDestroyScript.getGenNum() == 0){
//             // GENERATION 0
//             for(int i = 0; i < numOfCreatures; i++){
//                 creatureArray[i] = new Creature();
//                 creatureArray[i].CreatureNoParent(i,genNum, generationColor);
//                 // we pass this generations number as the creature is created in this generation
//             }
//         }
//         else{
//             // NOT GENERATION 0
//             for(int i = 0; i < numOfCreatures; i++){
//                 if (Random.Range(0,100) <= 70){// 70% THE CREATURE WON'T BE A MUTATION
//                 genNum = dontDestroyScript.getGenNum();
//                 creatureArray[i] = new Creature();
//                 creatureArray[i].CreatureWithParent(i ,dontDestroyScript.getCr1().getCreatureGen() ,dontDestroyScript.getGenColor(), dontDestroyScript.getCr1(), dontDestroyScript.getCr2());// also pass a creature number i using this constructor
//                 } else{ // MUTATION
//                     creatureArray[i] = new Creature();
//                     creatureArray[i].CreatureNoParent(i,genNum, generationColor);
//                     // we pass this generations number as the creature is created in this generation
//                     numOfMutations++;
//                 }
//             }
//             Debug.Log("Generation: "+genNum + ". Number of mutations in this generation: " +numOfMutations);
//         }

        
//         setCamera(creatureArray[0]);
//         // TEMPorarailly set the new target as the first creature in the array, for testing purposes
//         bestCreature = calculateBestCreature();
        

//         // timeScript, assing value to use later
//         timeScript = GameObject.Find("Timer").GetComponent<TimeScript>();

//         sceneRestartScript = GameObject.Find("SceneRestart").GetComponent<SceneRestart>();
        
//     }

//     // Update is called once per frame
//     void Update()
//     {   


//         // time measurer
//         timeElapsed = timeScript.getTime();
//         if (timeElapsed >= 10){
//             sceneRestartScript.RestartScene(genNum + 1, bestCreature, secondBestCreature, bestCreature.getGenColor());
//         }

//         bestCreature = calculateBestCreature();
//         //Debug.Log("Best creature at time " + timeElapsed + ", CREATURE NUM : " + bestCreature.getCreatureNum() + " has travelled " + bestCreature.getCreatureDistance());
//         secondBestCreature = calculateSecondBestCreature();
//         //Debug.Log("SECOND best creature at time " + timeElapsed + ", CREATURE NUM : " + secondBestCreature.getCreatureNum() + " has travelled " + secondBestCreature.getCreatureDistance());
        
//         setCamera(bestCreature);
        

//     }

//     void populateCreatureArray(){
//         // this function is used at the Start() funciton
        
//     }
//     Creature calculateBestCreature(){
//         if (currentBestCreature == null){//for the first time this function is called
//             currentBestCreature = creatureArray[0];
//         }
    
//         for (int i = 0; i< numOfCreatures; i++){
//             if (creatureArray[i].getCreatureDistance() >= currentBestCreature.getCreatureDistance()){
//                 currentBestCreature = creatureArray[i];
//             }
//         }
//         /*
//         // Assign the best creature the colo rblack so its easilly recongiszble
//         if (bestCreature != null){
//                 bestCreature.assignCreatureColor(bestCreature.getCreatureColor());// give the previous best creature its orignal color
//         }
        
//         currentBestCreature.assignCreatureColor(Color.black); // assigne the creature's color to black so its easilly recongisable
//         */
        
//         return (currentBestCreature);
//     }

//     Creature calculateSecondBestCreature(){

//         currentSecondBestCreature = creatureArray[0];// TEMP THIS MUST CHANGE!!! IT WILL BREAK THE EXPERIMENT!!

//         for(int i = 0; i < numOfCreatures; i++){
//             currentCreature = creatureArray[i];
//             if ((currentCreature.getCreatureDistance() >= currentSecondBestCreature.getCreatureDistance())&&(currentCreature.getCreatureDistance() < bestCreature.getCreatureDistance())){
//                 currentSecondBestCreature = currentCreature;
//             }
//         }
//         //Debug.Log("SECOND best creature is creature number: " + currentSecondBestCreature.getCreatureNum());
//         return (currentSecondBestCreature);
//     }
    
//     // ========================================================================================================
//     // Getters and setters
//     // ========================================================================================================

//     public int getGenNum(){
//         return genNum;
//     }
//     public Creature getBestCreature(){
//         return bestCreature;
//     }
//     public float getTimeElapsed(){
//         return timeElapsed;
//     }
    

//     void setCamera(Creature targetCreature){
//         newTarget = targetCreature.getCreatureBody().transform;
//         cameraFollowScript.setTarget(newTarget);
//         //Debug.Log("Following creature: " + targetCreature.getCreatureNum());
//     }

    

// }
