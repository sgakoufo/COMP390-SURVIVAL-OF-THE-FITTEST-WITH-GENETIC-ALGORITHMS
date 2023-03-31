using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 75f; // The speed at which the car moves
    public Transform frontWheel; // The front wheel of the car
    public Transform rearWheel; // The rear wheel of the car

    private Rigidbody2D rb; // The Rigidbody component of the car
    public float wheelRotationSpeed; // The speed at which the wheels rotate
    private float totalWheelSize;
    public float adjustedSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component of the car
        // THIS SHOULD BE DIFFERENT DEPENDING ON WHAT TYPE THE WHEEL IS
        totalWheelSize = (frontWheel.localScale.x + frontWheel.localScale.y)/2 + (rearWheel.localScale.x + rearWheel.localScale.y)/2; // Calculate the total size of both wheels
        wheelRotationSpeed = 5*(speed / totalWheelSize); // Calculate the wheel rotation speed based on the size of the wheels
    }

    private void FixedUpdate()
    {
    
        Vector2 movement = new Vector2(1, 0); // Combine the horizontal and vertical input axes into a movement vectors
        adjustedSpeed = speed / totalWheelSize; // Adjust the speed based on the size of the wheels
        rb.AddForce(movement * adjustedSpeed); // Apply a force to the car in the direction of the movement vector

        float rotation = -1 * wheelRotationSpeed * Time.fixedDeltaTime; // Calculate the rotation angle of the wheels based on the horizontal input axis
        frontWheel.Rotate(Vector3.forward, rotation); // Rotate the front wheel
        rearWheel.Rotate(Vector3.forward, rotation); // Rotate the rear wheel
    }
}

