using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
// this script will be used to follow the creature going the furthest
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }

    public void setTarget( Transform newTarget){
        target = newTarget;
    }
}


