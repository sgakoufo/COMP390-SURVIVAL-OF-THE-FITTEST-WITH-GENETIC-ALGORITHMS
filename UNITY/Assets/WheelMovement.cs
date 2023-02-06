using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    [SerializeField] WheelJoint2D wheel;

    public float acceleration = 100f;
    public float breakForce = 50f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;

    private void FixedUpdate(){
        // if space is pressed, start breaking
        if (Input.GetKey(KeyCode.Space)){
            currentBreakForce = breakForce;
        }else{
            currentBreakForce = 0f;
        }

        //apply acceeration to wheel
        GetComponent<WheelJoint2D>().motorSpeed = currentAcceleration;
    }    

}
