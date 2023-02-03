using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    Rigidbody2D body;
    bool onGround = true;
    void Awake() {                                                          //Happens on startup
        body = GetComponent<Rigidbody2D>();                                 //Gets the Player and names it 'body'
    }
    void Update() {                                                         //Updates every frame
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && onGround) {
            Jump();
        }
        else {}
    }

    void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        onGround = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {                        //Detects collision
        if (collision.gameObject.tag == "Ground") {                         //Custom tag "Ground"
            onGround = true;
        }
        
    }
}
