using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<50; i++){
            GenerateCreature();
        }
    }


    void GenerateCreature(){
        // ========================================================================================================
        // Generate creatureObject
        // ========================================================================================================
        GameObject creatureObject = new GameObject("creatureObject");
        // Set creatureObject as the parent:
        creatureObject.transform.SetParent(transform, false);

        int creatureLayerIndex = LayerMask.NameToLayer("Creature");
         // Get creatureLayer Index. The layer will be assigned to each of the creature's body and limbs
         // so that the creatures dont interact with each other.


        // ========================================================================================================
        // creatureBody:
        // ========================================================================================================
        GameObject creatureBody = new GameObject("creatureBody");
        creatureBody.transform.SetParent(creatureObject.transform, false);// Set carObject as the parent of carBody
        creatureBody.layer = creatureLayerIndex; // Set creature layer so creatures dont ineteract

        // Scale and position of the body:
        creatureBody.transform.localScale    = new Vector3(3f,1f,1f);
        creatureBody.transform.localPosition = new Vector3(0f,0f,0f);

        // creatureBody componets:
        // SpriteRender loads the body's sprite.(The circle basically)
        SpriteRenderer creatureBodyRender = creatureBody.AddComponent<SpriteRenderer>();
        Sprite       creatureBodySprite = Resources.Load<Sprite>("creatureBodySprite");// finds the sprite in the
                                                                                       // Assets/Resources folder
        creatureBodyRender.sprite = creatureBodySprite; // Assign the sprite

        // Set a random shade of gray for the creature body// TEMP, THIS CAN CHAGNE SO THE CREAUTRES OF SAME FAM CAN HAVE SAME COLORS!
        float gray = Random.Range(0.8f, 1.0f); // Generate a random shade of gray
        creatureBodyRender.color = new Color(gray, gray, gray, 1.0f); // set the color
        
        // Physics componets:
        Rigidbody2D creatureBodyRB = creatureBody.AddComponent<Rigidbody2D>();
        creatureBody.AddComponent<BoxCollider2D>();
        creatureBodyRB.mass = 1f; // set the body mass

        // ========================================================================================================
        // Generate the wheels
        // ========================================================================================================

        generateWheel( 1.5f, 0.5f, -0.5f, creatureObject, creatureBodyRB);// Generate front wheel
        generateWheel(-1.5f,-0.5f, -0.5f, creatureObject, creatureBodyRB);// Generate back  wheel

        // ========================================================================================================
        // Movement
        // ========================================================================================================

        CarMovement07 carMovementScript = creatureBody.AddComponent<CarMovement07>();// Add the movement scipr to the CREATURE BODY
                                                                                                // Create a reference to the script so we can
                                                                                                // chage the speed
        float randomSpeed = Random.Range(0f,5f); //generate speed value randoml. This will later change with genetic algorithms. Also thisr ange is temp, it can change
        carMovementScript.setSpeed(randomSpeed); 

    }

    void generateWheel(float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB){
        // x1 is the x axis for the wheel transform, x2 is fote the wheelJoint2D connected anchor value. Y statys the same
        // we have x1 and x2 so the creature generates cleanly
        // ========================================================================================================
        // Generate wheel:
        // ========================================================================================================
        GameObject wheel = new GameObject("wheel");
        // Set creatureObject as teh wheel's parent:
        wheel.transform.SetParent(creatureObject.transform, false);
        int creatureLayerIndex = LayerMask.NameToLayer("Creature");
        wheel.layer = creatureLayerIndex; // set wheel layer to creature so creatures they dont interact
         
        // ========================================================================================================
        // Give wheel its components
        // ========================================================================================================
        // SpriteRender loads the wheel's sprite.(The circle basically)
        SpriteRenderer wheelRenderer = wheel.AddComponent<SpriteRenderer>();
        Sprite       wheelSprite    = Resources.Load<Sprite>("wheelSprite");// finds the sprite in the
                                                                            // Assets/Resources folder
        wheelRenderer.sprite = wheelSprite;// Assign the sprite
        // wheel position:
        wheel.transform.localPosition = new Vector3(x1,y,0f);

        // Physics Componets:
        Rigidbody2D wheelRB;
        wheelRB = wheel.AddComponent<Rigidbody2D>();
        wheelRB.mass = 5f;// set mass
        wheel.AddComponent<CircleCollider2D>();


        // ========================================================================================================
        // wheelJoint2D(Most important one)
        // ========================================================================================================
       
        WheelJoint2D wheelJoint                 = wheel.AddComponent<WheelJoint2D>();
        wheelJoint.connectedBody                = creatureBodyRB;
        wheelJoint.anchor                       = new Vector2(0f,0f);
        wheelJoint.autoConfigureConnectedAnchor = false;
        wheelJoint.connectedAnchor              = new Vector2(x2,-0.5f);
        // wheel suspension:
        JointSuspension2D suspension = wheelJoint.suspension;
        suspension.frequency         = 20.0f; // 20 so it doens't bounce. This can be cahnged
        wheelJoint.suspension        = suspension;

        // ========================================================================================================
        // Wheel Size
        // ========================================================================================================
        //Rnadomly generate wheel size for now
        float randomWheelSize = Random.Range(0f,3f);// this range is temp, can chage.
        wheel.transform.localScale = new Vector2(randomWheelSize, randomWheelSize);
                                                                                    



    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
