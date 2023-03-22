using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    // ========================================================================================================
    // private variables
    // ========================================================================================================
    private float radius;

    // can add more variables as time goes on
    // ========================================================================================================
    // Constructors
    // ========================================================================================================
    public void WheelNoParent(float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB, float color){
        // this constructor is called when there are no parents
        radius = Random.Range(0f,3f);// TEMP, this range can change
        generateWheel(x1 ,x2 ,y ,creatureObject, creatureBodyRB,color);
    }
    /*
    public void WheelWithParent(float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB, Wheel w1, Wheel w2){
        // this constructor is for when there are parents. It generates the wheel values accordingly
        radius = Random.Range(Mathf.Min(w1.getRadius(), w2.getRadius()), Mathf.Max(w1.getRadius(), w2.getRadius()));
        generateWheel(x1 ,x2 ,y ,creatureObject, creatureBodyRB);
    }
    */ 
    // TEMP COMMENTED OUT TO KEEP THINGS SIMPLE

    void generateWheel(float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB, float color){
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
        wheelRenderer.color = new Color(color, color, color, 1.0f); // set the color
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
        // Wheel Attributes
        // ========================================================================================================
        // Give wheel its attributes we got from the parents( or generated randomly, if no parents)
        // radius
        float wheelSize = getRadius();
        wheel.transform.localScale = new Vector2(wheelSize, wheelSize);
                                                                                    



    }



    // ========================================================================================================
    // Getters and setters
    // ========================================================================================================

    public void setRadius(float rad){
        radius = rad;
    }

    public float getRadius(){
        return radius;
    }

}
