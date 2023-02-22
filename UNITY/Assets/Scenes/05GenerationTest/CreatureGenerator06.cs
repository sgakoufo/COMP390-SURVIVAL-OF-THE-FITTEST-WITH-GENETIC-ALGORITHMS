// Creature generator. Last updateD: 14 Feb 2023, 18:12

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureGenerator05OLD : MonoBehaviour
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
        //Give carBody its Components
        //Sprite renderer so the carbody is an actual square and not nothingness
        SpriteRenderer carBodyRenderer = carBody.AddComponent<SpriteRenderer>();
        carBodySprite = Resources.Load<Sprite>("carBodySprite");//Find the sprite in the Resources folder
        carBodyRenderer.sprite = carBodySprite;// Assign the sprite to the SpriteRenderer component
        carBody.transform.localScale = new Vector3(3f, 1f, 1f);

        //Physics Components
        carBody.AddComponent<BoxCollider2D>();
        Rigidbody2D carBodyRB= carBody.AddComponent<Rigidbody2D>(); // assign it to a variable so that
                                                                    // we can use it on the wheel join
        
                                                                              
        //Generate wheels
        GameObject frontWheel = new GameObject ("frontWheel");
        frontWheel.transform.SetParent(carObject.transform,false);// Set carObject as the parent of the frontWheel
        //give frontWheel its components
        SpriteRenderer frontWheelRenderer = frontWheel.AddComponent<SpriteRenderer>();
        frontWheelSprite = Resources.Load<Sprite>("frontWheelSprite"); // Find the sprite in the Resourcs folder
        frontWheelRenderer.sprite = frontWheelSprite;// Assign the sprite to the SpriteRender componet
        
        // Physics Components
        frontWheel.AddComponent<Rigidbody2D>();
        frontWheel.AddComponent<CircleCollider2D>();

        // wheelJoin2D Component (important one)
        WheelJoint2D frontWheelJoint = frontWheel.AddComponent<WheelJoint2D>();
        frontWheelJoint.connectedBody = carBodyRB;
        frontWheelJoint.anchor = new Vector2(0f,0f);
        frontWheelJoint.autoConfigureConnectedAnchor  = false;
        frontWheelJoint.connectedAnchor = new Vector2(0.5f,-0.5f);
        // change wheelJoint suspension so the car doesnt bounce
        JointSuspension2D suspension = frontWheelJoint.suspension;
        suspension.frequency = 20.0f;
        frontWheelJoint.suspension = suspension;

    }

    void GenerateWheels(int x, int y){
        
    }
    // Update is called once per frame
    
    void Update(){
    
    }
}
