// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Wheel : MonoBehaviour
// {
//     // ========================================================================================================
//     // private variables
//     // ========================================================================================================
//     private int wheelType; 
//     // wheelType = 1 means circle
//     // wheelType = 2 means rectangle
//     private float radiusX;
//     private float radiusY;
//     private SpriteRenderer wheelRenderer;
//     private Sprite wheelSprite;
//     private BoxCollider2D boxCollider;

//     // can add more variables as time goes on
//     // ========================================================================================================
//     // Constructors
//     // ========================================================================================================
//     public void WheelNoParent(string wheelName, float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB, Color color){
//         // this constructor is called when there are no parents
//         wheelType = Random.Range(1,3);
//         radiusX = Random.Range(0.5f,2f);// TEMP, this range can change
//         radiusY = Random.Range(0.5f,2f);// TEMP, this range can change
//         generateWheel(wheelName,x1 ,x2 ,y ,creatureObject, creatureBodyRB,color);
//     }
    
//     public void WheelWithParent(string wheelName,float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB, Color color, Wheel w1, Wheel w2){
//         // this constructor is for when there are parents. It generates the wheel values accordingly
//         if (w1.getWheelType() == w2.getWheelType()){
//             // if parent wheels are the same type, assign the same type
//             wheelType = w1.getWheelType();
//         } else{
//             // if they are different, 50/50 chance of wheel type.
//             wheelType = Random.Range(1,2);
//         }
//         radiusX = Random.Range(Mathf.Min(w1.getRadiusX(), w2.getRadiusX()), Mathf.Max(w1.getRadiusX(), w2.getRadiusX()));
//         radiusY = Random.Range(Mathf.Min(w1.getRadiusY(), w2.getRadiusY()), Mathf.Max(w1.getRadiusY(), w2.getRadiusY()));
//         generateWheel(wheelName, x1 ,x2 ,y ,creatureObject, creatureBodyRB, color);
//     }

//     // TEMP COMMENTED OUT TO KEEP THINGS SIMPLE

//     void generateWheel(string wheelName,float x1, float x2, float y, GameObject creatureObject, Rigidbody2D creatureBodyRB, Color wheelColor){
//         // x1 is the x axis for the wheel transform, x2 is fote the wheelJoint2D connected anchor value. Y statys the same
//         // we have x1 and x2 so the creature generates cleanly
//         // ========================================================================================================
//         // Generate wheel:
//         // ========================================================================================================
//         GameObject wheel = new GameObject(wheelName);
//         // Set creatureObject as teh wheel's parent:
//         wheel.transform.SetParent(creatureObject.transform, false);
//         int creatureLayerIndex = LayerMask.NameToLayer("Creature");
//         wheel.layer = creatureLayerIndex; // set wheel layer to creature so creatures they dont interact
         
         
//         // ========================================================================================================
//         // Give wheel its components
//         // ========================================================================================================
//         // SpriteRender loads the wheel's sprite.(The circle basically)
//         wheelRenderer = wheel.AddComponent<SpriteRenderer>();
        
//         if (wheelType == 1){
//             wheelSprite = Resources.Load<Sprite>("circleSprite");// finds the sprite in the / Assets/Resources folder
//             wheel.AddComponent<CircleCollider2D>();
//             wheel.transform.localScale = new Vector2(radiusX, radiusX);
//         }else if (wheelType == 2){
//             wheelSprite = Resources.Load<Sprite>("rectangleSprite");// finds the sprite in the / Assets/Resources folder
//             boxCollider = wheel.AddComponent<BoxCollider2D>();
//             boxCollider.size = new Vector3(radiusX, radiusY, 0);
//             wheel.transform.localScale = new Vector2(radiusX, radiusY);
//         }else{
//             Debug.Log("Invalid wheel Sprite)");
//         }
//         wheelRenderer.sprite = wheelSprite;// Assign the sprite
//         assignWheelColor(wheelColor);
//         // wheel position:
//         wheel.transform.localPosition = new Vector3(x1,y,0f);

//         // Physics Componets:
//         Rigidbody2D wheelRB;
//         wheelRB = wheel.AddComponent<Rigidbody2D>();
//         wheelRB.mass = 5f;// set mass
        


//         // ========================================================================================================
//         // wheelJoint2D(Most important one)
//         // ========================================================================================================
       
//         WheelJoint2D wheelJoint                 = wheel.AddComponent<WheelJoint2D>();
//         wheelJoint.connectedBody                = creatureBodyRB;
//         wheelJoint.anchor                       = new Vector2(0f,0f);
//         wheelJoint.autoConfigureConnectedAnchor = false;
//         wheelJoint.connectedAnchor              = new Vector2(x2,-0.5f);
//         // wheel suspension:
//         JointSuspension2D suspension = wheelJoint.suspension;
//         suspension.frequency         = 20.0f; // 20 so it doens't bounce. This can be cahnged
//         wheelJoint.suspension        = suspension;

//         // ========================================================================================================
//         // Wheel Attributes
//         // ========================================================================================================
//         // Give wheel its attributes we got from the parents( or generated randomly, if no parents)
//         // radius
        
        

//     }
//     public void assignWheelColor(Color color_){
//         wheelRenderer.material.color = color_;
//     }


//     // ========================================================================================================
//     // Getters and setters
//     // ========================================================================================================

//     public void setRadiusX(float rad){
//         radiusX = rad;
//     }

//     public float getRadiusX(){
//         return radiusX;
//     }

//     public void setRadiusY(float rad){
//         radiusY = rad;
//     }

//     public float getRadiusY(){
//         return radiusY;
//     }

//     public int getWheelType(){
//         return wheelType;
//     }
// }
