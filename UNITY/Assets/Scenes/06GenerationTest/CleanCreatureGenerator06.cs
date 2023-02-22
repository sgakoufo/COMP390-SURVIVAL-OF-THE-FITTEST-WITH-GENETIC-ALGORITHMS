using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanCreatureGenerator06 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateCreature();
    }


    void GenerateCreature(){
        // ========================================================================================================
        // Generate creatureObject
        // ========================================================================================================
        GameObject creatureObject = new GameObject("creatureObject");
        // Set creatureObject as the parent:
        creatureObject.transform.SetParent(transform, false);

        // ========================================================================================================
        // creatureBody:
        // ========================================================================================================
        GameObject creatureBody = new GameObject("creatureBody");
        // Scale and position of the body:
        creatureBody.transform.localScale    = new Vector3(3f,1f,1f);
        creatureBody.transform.localPosition = new Vector3(0f,0f,0f);

        // creatureBody componets:
        // SpriteRender loads the body's sprite.(The circle basically)
        SpriteRenderer creatureBodyRender = creatureBody.AddComponent<SpriteRenderer>();
        Sprite       creatureBodySprite = Resources.Load<Sprite>("creatureBodySprite");// finds the sprite in the
                                                                                       // Assets/Resources folder
        creatureBodyRender.sprite = creatureBodySprite; // Assign the sprite
        
        // Physics componets:
        Rigidbody2D creatureBodyRB = creatureBody.AddComponent<Rigidbody2D>();
        creatureBody.AddComponent<BoxCollider2D>();
        creatureBodyRB.mass = 1f; // set the body mass

        // ========================================================================================================
        // Generate the wheels
        // ========================================================================================================

        generateWheel( 0.5f, -0.5f, creatureObject, creatureBodyRB);// Generate front wheel
        generateWheel(-0.5f, -0.5f, creatureObject, creatureBodyRB);// Generate back  wheel
    }

    void generateWheel(float x, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB){
        // ========================================================================================================
        // Generate wheel:
        // ========================================================================================================
        GameObject wheel = new GameObject("wheel");
        // Set creatureObject as teh wheel's parent:
        wheel.transform.SetParent(creatureObject.transform, false);

         
        // ========================================================================================================
        // Give wheel its components
        // ========================================================================================================
        // SpriteRender loads the wheel's sprite.(The circle basically)
        SpriteRenderer wheelRenderer = wheel.AddComponent<SpriteRenderer>();
        Sprite       wheelSprite    = Resources.Load<Sprite>("wheelSprite");// finds the sprite in the
                                                                            // Assets/Resources folder
        wheelRenderer.sprite = wheelSprite;// Assign the sprite
        // wheel position:
        wheel.transform.localPosition = new Vector3(x,y,0f);

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
        wheelJoint.connectedAnchor              = new Vector2(x,y);
        // wheel suspension:
        JointSuspension2D suspension = wheelJoint.suspension;
        suspension.frequency         = 20.0f; // 20 so it doens't bounce. This can be cahnged
        wheelJoint.suspension        = suspension;


                                                                                    



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
