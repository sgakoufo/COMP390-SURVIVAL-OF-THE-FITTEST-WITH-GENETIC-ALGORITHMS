/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Public variable to set the speed of the car. The speed will be set by another class, at the moment CreatureGenerator script, but this may change.
    private float angularVelocity;
    private float linearVelocity;
    public GameObject creatureObject;
    public GameObject creatureBody;
    public GameObject frontWheel;
    public GameObject backWheel;

    // Private variable to store the Rigidbody2D component of the car
    private Rigidbody2D rb2d;
    
    public void Start()
    {
        //creatureObject = transform.find("Creat
        
        // Get the Rigidbody2D component attached to the car
        rb2d = GetComponent<Rigidbody2D>();
        calculateSpeed();

        // If we want the car to constnalty move forward:
        Vector2 movement = new Vector2(1, 0);
        rb2d.velocity = movement * speed;
    }
 

    private float calculateLinearVelocity(){
        

    }
}
*/
 