using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    DontDestroy dontDestroyScript;


    void Start(){
        // refrence to the dontDestroy script
        dontDestroyScript = GameObject.Find("DontDestroy").GetComponent<DontDestroy>();
    }
    public void RestartScene(int genNum, Creature cr1, Creature cr2, Color genColor){
        // this function restarts the current scene. It will be used by the simulation class
        // to restart the scene/simulation when deemed neccessary
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);// Gets the currents scene and restarts it
        SceneManager.sceneLoaded += OnSceneLoaded; // += means that OnSceneLoaded will be called automatically too when a new scene is loaded
        // note that OnSceneLoaded will be handles by unity and i do not need to give any parameters
        // SceneManager.sceneLoaded is an event triggered when a new scene finehses loaded
        // And you use this event to perform actions such as intilaisjg objects or passing values
        //between scenes. In our case its the Generation number and the Best Creatures

        dontDestroyScript.saveGenVars(genNum, cr1, cr2, genColor);  
        Debug.Log("Saved values: genNum: "+ genNum + ", cr1: " + cr1.getCreatureNum() + ", cr2: " + cr2.getCreatureNum()); 
        
        

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    // This method will be called automatically by Unity whenever a new scene is loaded
    // You can use it to perform any actions that need to be taken after a scene has finished loading
    // In our case, we will use it to pass the values between scenes
    
}

}
 