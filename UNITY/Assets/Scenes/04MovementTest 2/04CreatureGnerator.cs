// Creature generator. Last updateD: 14 Feb 2023, 18:12

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureGnerator : MonoBehaviour
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
        carBody.AddComponent<Rigidbody2D>();
        carBody.AddComponent<BoxCollider2D>();


        //Generate wheels
        

    }
    // Update is called once per frame
    void Update()
    {

    }
}
