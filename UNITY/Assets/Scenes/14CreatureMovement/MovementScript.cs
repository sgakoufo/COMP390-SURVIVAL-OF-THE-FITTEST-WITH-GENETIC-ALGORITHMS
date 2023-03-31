/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // THIS SCRIPT IS ATTACHED TO EACH CREATURE BODY!
    // TEMP: FIND A WAY TO ACESS THE WHEELS, IT SHOULDNT BE THAT BAD.
    public float speed = 400f; // The speed at which the creature moves
    public Transform frontWheel; // The front wheel of the creature
    public Transform backWheel; // The back wheel of the creature

    private float totalWheelSize;
    private Rigidbody2D creatureBodyRB; // The Rigidbody component of the car
    public float wheelRotationSpeed; // The speed at which the wheels rotate

    private void Start()
    {
        
        creatureBodyRB = GetComponent<Rigidbody2D>(); // Get the Rigidbody component of the creature
        // THIS SHOULD BE DIFFERENT DEPENDING ON WHAT TYPE THE WHEEL IS

        totalWheelSize = (frontWheel.localScale.x + frontWheel.localScale.y)/2 + (backWheel.localScale.x + backWheel.localScale.y)/2 ; // Calculate the total size of both wheels
        // this equation works due to the way unity changes shape size, even for circles. yt
        wheelRotationSpeed = 4*(speed / totalWheelSize); // Calculate the wheel rotation speed based on the size of the wheels
        // 5 IS A TEMP number, but this proved to be usefull so the reatagles actually rotaote. Their rotaitons doenst actualyl move the car,
        // but it helps them get over obstacles
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(1, 0); // creature constantly moves forward
        float adjustedSpeed = speed / totalWheelSize; // Adjust the speed based on the size of the wheels
        // the bigger the wheels, the slower the car goes. This "speed" is a force attached direclty to the
        // car body. The creature doesnt ahve to strugle with unecssary physics where it is pushed more from one whele
        // than the other
        creatureBodyRB.AddForce(movement * adjustedSpeed); // Apply a force to the car in the direction of the movement vector

        float rotation = -1 * wheelRotationSpeed * Time.fixedDeltaTime; // Calculate the rotation angle of the wheels based on the horizontal input axis
        frontWheel.Rotate(Vector3.forward, rotation); // Rotate the front wheel
        backWheel.Rotate(Vector3.forward, rotation); // Rotate the rear wheel
    }
}

*/