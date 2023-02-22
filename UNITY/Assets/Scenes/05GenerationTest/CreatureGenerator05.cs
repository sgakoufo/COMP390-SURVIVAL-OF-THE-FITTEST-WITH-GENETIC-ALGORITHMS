// Creature generator. Last updateD: 14 Feb 2023, 18:12

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureGenerator05 : MonoBehaviour
{

    private Sprite carBodySprite;
    private Sprite frontWheelSprite;
    private Sprite backWheelSprite;


    // Start is called before the first frame update
    void Start()
    {
        GenerateCar();
    }


    void GenerateCar(){

        //Generate carObject
        GameObject carObject = new GameObject("carObject");
        carObject.transform.SetParent(transform, false);// Set the carObject as a parent.

        //Generate carBody
        GameObject carBody = new GameObject("carBody");
        carBody.transform.SetParent(carObject.transform, false);// Set carObject as the parent of carBody
        // scale and psotion of carBody
        carBody.transform.localScale = new Vector3(3f, 1f, 1f);
        carBody.transform.localPosition = new Vector3(0f, 0f, 0f);

        //Give carBody its Components
        //Sprite renderer so the carbody is an actual square and not nothingness
        SpriteRenderer carBodyRenderer = carBody.AddComponent<SpriteRenderer>();
        carBodySprite = Resources.Load<Sprite>("carBodySprite");//Find the sprite in the Resources folder
        carBodyRenderer.sprite = carBodySprite;// Assign the sprite to the SpriteRenderer component



        //Physics Components
        carBody.AddComponent<BoxCollider2D>();
        Rigidbody2D carBodyRB= carBody.AddComponent<Rigidbody2D>(); // assign it to a variable so that
                                                                    // we can use it on the wheel join
        carBodyRB.mass = 1f; //set mass             
        // generate the wheels                                                                     
        GenerateWheel(0.5f,-0.5f,carObject,carBodyRB);
        GenerateWheel(-0.5f,-0.5f,carObject,carBodyRB);

        // add the movement script
        carBody.AddComponent<CarMovement05>();
        

    }

    void GenerateWheel(float x, float y, GameObject carObject, Rigidbody2D carBodyRB){ 
        GameObject wheel = new GameObject ("wheel");
        wheel.transform.SetParent(carObject.transform,false);// Set carObject as the parent of the wheel
    
        //give wheel its components
        SpriteRenderer wheelRenderer = wheel.AddComponent<SpriteRenderer>();
        Sprite wheelSprite;
        wheelSprite = Resources.Load<Sprite>("wheelSprite"); // Find the sprite in the Resourcs folder
        wheelRenderer.sprite = wheelSprite;// Assign the sprite to the SpriteRender componet
        
        // Physics Components
        Rigidbody2D wheelRB;
        wheelRB = wheel.AddComponent<Rigidbody2D>();
        wheel.AddComponent<CircleCollider2D>();

        // wheelJoin2D Component (important one)
        WheelJoint2D wheelJoint = wheel.AddComponent<WheelJoint2D>();
        wheelJoint.connectedBody = carBodyRB;
        wheelJoint.anchor = new Vector2(0f,0f);
        wheelJoint.autoConfigureConnectedAnchor  = false;
        wheelJoint.connectedAnchor = new Vector2(x,y);
        // change wheelJoint suspension so the car doesnt bounce
        JointSuspension2D suspension = wheelJoint.suspension;
        suspension.frequency = 20.0f;
        wheelJoint.suspension = suspension;

        wheelRB.mass = 5f;// set mass

        // wheel psotion
        wheel.transform.localPosition = new Vector3(x, y, 0f);
    }
    // Update is called once per frame
    
    void Update(){
    
    }
}
