using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // ========================================================================================================
    // private variables
    // ========================================================================================================
    private int numOfWheels = 2;//Temp, might change
    private Wheel[] wheelArray = new Wheel[2]; // 2 IS TEMP
    private float speed = 0;
    private float color = 0;
    // OTHER VARIABLES WE CAN HAVE ARE BODYSHAPE;

    private float distanceTravelled = 0;

    //variables to pass to Wheel Constructor:

    private float x1 =  1.5f;// TEMP, THIS SHOULD CHANGE. ITS JUST NUMBERS FOR GENERATING WHEE
    private float x2 =  0.5f;// TEMP, THIS SHOULD CHANGE. ITS JUST NUMBERS FOR GENERATING WHEE
    private float y  = -0.5f;// TEMP, THIS SHOULD CHANGE. ITS JUST NUMBERS FOR GENERATING WHEEL

    private GameObject     creatureObject;
    private Rigidbody2D    creatureBodyRB;
    private GameObject     creatureBody;
    private SpriteRenderer creatureBodyRender;
    private Sprite         creatureBodySprite;

    // can add more variables as time goes on
    // ========================================================================================================
    // Constructors
    // ========================================================================================================
    
    public void CreatureNoParent(){
        // construcotr for when the craeture does not have any parents(Generation 1 creature, or Mutation)
        generateCreature();
        //TEMP, THIS IS HARD CODED IN FOR ONLY TWO WHEELS. SHOULD PROBABLY BE HARD CODED IN FOR HOWEVER MANY WHEELS WE CHOSE
        // Front wheel:
        wheelArray[0] = new Wheel();
        wheelArray[0].WheelNoParent(x1, x2, y, creatureObject, creatureBodyRB, color);
        // Back wheel:
        wheelArray[1] = new Wheel();
        wheelArray[1].WheelNoParent(-x1, -x2, y, creatureObject, creatureBodyRB, color);  
    }
    /*
    public void CreatureWithParent(Creature cr1, Creature cr2){
        // constructor for when the creature has parents, cr1 and cr2
        generateCreature();
        for(int i = 0; i < numOfWheels; i++){
            wheelArray[i] = wheelArray[i].WheelWithParent(x1, x2, y, creatureObject, creatureBodyRB, cr1.wheelArray[i], cr2.wheelArray[i]);
        }
        
    }*/
    // TEMP commented out to keep things simple


    void generateCreature(){
        // ========================================================================================================
        // Generate creatureObject
        // ========================================================================================================
        creatureObject = new GameObject("creatureObject");
        // Set creatureObject as the parent:
        //creatureObject.transform.SetParent(transform, false);// This doesnt work but we dont really need it

        int creatureLayerIndex = LayerMask.NameToLayer("Creature");
         // Get creatureLayer Index. The layer will be assigned to each of the creature's body and limbs
         // so that the creatures dont interact with each other.


        // ========================================================================================================
        // creatureBody:
        // ========================================================================================================
        creatureBody = new GameObject("creatureBody");
        creatureBody.transform.SetParent(creatureObject.transform, false);// Set carObject as the parent of carBody
        creatureBody.layer = creatureLayerIndex; // Set creature layer so creatures dont ineteract

        // Scale and position of the body:
        creatureBody.transform.localScale    = new Vector3(3f,1f,1f);
        creatureBody.transform.localPosition = new Vector3(0f,0f,0f);

        // creatureBody componets:
        // SpriteRender loads the body's sprite.(The circle basically)
        creatureBodyRender = creatureBody.AddComponent<SpriteRenderer>();
        creatureBodySprite = Resources.Load<Sprite>("creatureBodySprite");// finds the sprite in the
                                                                                       // Assets/Resources folder
        creatureBodyRender.sprite = creatureBodySprite; // Assign the sprite

        // Set a random shade of gray for the creature body// TEMP, THIS CAN CHAGNE SO THE CREAUTRES OF SAME FAM CAN HAVE SAME COLORS!
        color = Random.Range(0.0f, 1.0f); // Generate a random shade of gray
        creatureBodyRender.color = new Color(color, color, color, 1.0f); // set the color
        
        // Physics componets:
        creatureBodyRB = creatureBody.AddComponent<Rigidbody2D>();
        creatureBody.AddComponent<BoxCollider2D>();
        creatureBodyRB.mass = 1f; // set the body mass


        // ========================================================================================================
        // Movement
        // ========================================================================================================

        CarMovement07 carMovementScript = creatureBody.AddComponent<CarMovement07>();// Add the movement scipr to the CREATURE BODY
                                                                                                // Create a reference to the script so we can
                                                                                                // chage the speed
        float randomSpeed = Random.Range(0f,5f); //generate speed value randoml. This will later change with genetic algorithms. Also thisr ange is temp, it can change
        carMovementScript.setSpeed(randomSpeed); 
        
    }
    
    

    // ========================================================================================================
    // Getters and setters
    // ========================================================================================================

    public GameObject getCreatureObject(){
        return creatureObject;
    }

    public GameObject getCreatureBody(){
        return creatureBody;
    }

    public float getCreatureBodyLocalX(){
        return creatureBody.transform.localPosition.x;
    }
}
