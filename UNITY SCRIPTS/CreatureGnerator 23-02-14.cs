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
        carBodySprite = Resources.Load<Sprite>("Assets/Scenes/04MovementTest 2/carBodySprite.png");
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
        
        carBodyRenderer.sprite = carBodySprite;
        //Physics Components
        carBody.AddComponent<Rigidbody2D>();
        carBody.AddComponent<BoxCollider2D>();
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
