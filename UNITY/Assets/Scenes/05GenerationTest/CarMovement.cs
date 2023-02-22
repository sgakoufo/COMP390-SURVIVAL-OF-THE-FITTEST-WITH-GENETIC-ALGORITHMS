using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement05 : MonoBehaviour
{
    // Public variable to set the speed of the car
    public float speed = 02.0f;

    // Private variable to store the Rigidbody2D component of the car
    private Rigidbody2D rb2d;

    void Start()
    {
        // Get the Rigidbody2D component attached to the car
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get the horizontal and vertical input values from the user 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a Vector2 object with the horizontal and vertical input values
        // If we want the car to move with user input:
        //Vector2 movement = new Vector2(horizontal, vertical);
        // If we want the car to constnalty move forward:
        Vector2 movement = new Vector2(1, 0);

        // Set the velocity of the Rigidbody2D component to move the car
        rb2d.velocity = movement * speed;
    }
}
