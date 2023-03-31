using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    // ========================================================================================================
    // private variables
    // ========================================================================================================
    private int creatureNum; // This is the creature number
    
    //private int numOfWheels = 2;//Temp, might change
    private Wheel[] wheelArray = new Wheel[2]; // 2 IS TEMP
    private float speed = 0;
    private Color generationColor;
    private Color creatureColor;
    private int creatureGen;

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
    
   
    public void CreatureNoParent(int creatureNum_, int creatureGen_, Color generationColor_)
    {  
        generationColor = generationColor_;
        // construcotr for when the craeture does not have any parents(Generation 1 creature, or Mutation)
        creatureNum = creatureNum_;
        creatureGen = creatureGen_;// to keep track of which generation the best creature was generated in
        // this is passed on by the simulation class,
        // (we keep only the best creature not the second best)
    
  
        // speed:
        speed = Random.Range(0f,5f); //generate speed value randoml.
        generateRandomColorShade(generationColor);
        generateCreature();

        //TEMP, THIS IS HARD CODED IN FOR ONLY TWO WHEELS. SHOULD PROBABLY BE HARD CODED IN FOR HOWEVER MANY WHEELS WE CHOSE
        // Front wheel:
        wheelArray[0] = new Wheel();
        wheelArray[0].WheelNoParent(x1, x2, y, creatureObject, creatureBodyRB, creatureColor);
        // Back wheel:
        wheelArray[1] = new Wheel();
        wheelArray[1].WheelNoParent(-x1, -x2, y, creatureObject, creatureBodyRB, creatureColor);  
    }
    
    public void CreatureWithParent(int creatureNum_, int creatureGen_, Color generationColor_, Creature cr1, Creature cr2){
        generationColor = generationColor_;
        // constructor for when the creature has parents, cr1 and cr2
        creatureNum = creatureNum_;// assign creature number passed by the Simulation class
        creatureGen = creatureGen_;
        

        // speed:
        // this if statement is purely for the Random.Range fucntion. We cant have range between 5 and 3. must be between 3 and 5
        if (cr1.getSpeed() <= cr2.getSpeed()){
            speed = Random.Range(cr1.getSpeed(), cr2.getSpeed());
        }
        else{
            speed =Random.Range(cr2.getSpeed(),cr1.getSpeed());
        }
        generateRandomColorShade(generationColor);// 
        generateCreature();
        //TEMP, THIS IS HARD CODED IN FOR ONLY TWO WHEELS. SHOULD PROBABLY BE HARD CODED IN FOR HOWEVER MANY WHEELS WE CHOSE
        // Front wheel:
        wheelArray[0] = new Wheel();
        wheelArray[0].WheelWithParent(x1, x2, y, creatureObject, creatureBodyRB, creatureColor, cr1.wheelArray[0], cr2.wheelArray[0]);
        // Back wheel:
        wheelArray[1] = new Wheel();
        wheelArray[1].WheelWithParent(-x1, -x2, y, creatureObject, creatureBodyRB, creatureColor, cr1.wheelArray[1], cr2.wheelArray[1]);
    }
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
        
        // set color:
        creatureBodyRender.material.color = creatureColor;

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
        carMovementScript.setSpeed(speed); 
        
        
    }
    
    

    private void generateRandomColorShade(Color generationColor){
        // this funciton generates a random shade of the generation color.
        float hueOffset = Random.Range(-0.04f, 0.04f);
        float saturationOffset = Random.Range(-0.04f, 0.04f);
        float valueOffset = Random.Range(-0.04f, 0.04f);

        float h, s, v;
        Color.RGBToHSV(generationColor, out h, out s, out v);
        h += hueOffset;
        s += saturationOffset;
        v += valueOffset;
        creatureColor = Color.HSVToRGB(h, s, v);

    }
    
     public void assignCreatureColor(Color color_){
        // this functions assign;s the creature color to the givne color.
        // this will be used to highlight the creature color as UI, but it will not
        // change the creatureColor value so its easy to revert oncet this creature
        // isnt the bestCreature
         creatureBodyRender.material.color = color_;
         for (int i = 0; i< wheelArray.Length; i++){
            wheelArray[i].assignWheelColor(color_);
         }
    }

    // ========================================================================================================
    // Getters and setters
    // ========================================================================================================
    public int getCreatureNum(){
        return creatureNum;
    }

    public GameObject getCreatureObject(){
        return creatureObject;
    }

    public GameObject getCreatureBody(){
        return creatureBody;
    }

    public float getCreatureBodyLocalX(){
        return creatureBody.transform.localPosition.x;
    }

    public float getSpeed(){
        return speed;
    }

    public Color getGenColor(){
        return generationColor;
    }
    public Color getCreatureColor(){
        return creatureColor;
    }

    public float getCreatureDistance(){
        // this function caclulates the creature's current travelled distance
        distanceTravelled = creatureBody.transform.localPosition.x;
        return distanceTravelled;
    }

    public int getCreatureGen(){
        return creatureGen;
    }
    
   
}
