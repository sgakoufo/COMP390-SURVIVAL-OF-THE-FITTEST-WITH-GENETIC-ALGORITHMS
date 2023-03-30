using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 5f; // The speed at which the car moves
    public Transform frontWheel; // The front wheel of the car
    public Transform rearWheel; // The rear wheel of the car

    private Rigidbody2D rb; // The Rigidbody component of the car

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component of the car
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get the horizontal input axis (left or right arrow key)
        float moveVertical = Input.GetAxis("Vertical"); // Get the vertical input axis (up or down arrow key)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); // Combine the horizontal and vertical input axes into a movement vector
        rb.AddForce(movement * speed); // Apply a force to the car in the direction of the movement vector

        float rotation = -moveHorizontal * 30f; // Calculate the rotation angle of the wheels based on the horizontal input axis
        frontWheel.localRotation = Quaternion.Euler(0f, 0f, rotation); // Rotate the front wheel
        rearWheel.localRotation = Quaternion.Euler(0f, 0f, rotation); // Rotate the rear wheel
    }
}
