using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;                                   //Refrence to RigidBody2D Component
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();                     //Actually gets the RigidBody2D Component
    }
    private void Update()                                       //Updates every frame of the game
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
