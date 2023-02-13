using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    Rigidbody2D player;
    bool onGround = true;
    void Awake() {                                                          //Happens on startup
        player = GetComponent<Rigidbody2D>();                                 //Gets the Player and names it 'body'
    }
    void Update() {                                                         //Updates every frame
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y);

        if (Input.GetKey(KeyCode.Space) && onGround) {
            Jump();
        }
        else {}
    }

    void Jump() {
        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        onGround = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {                        //Detects collision
        if (collision.gameObject.tag == "Ground") {                         //Custom tag "Ground"
            onGround = true;
        }

        if (collision.gameObject.tag == "Enemy") {
            //Damage Player
            var healthComponent = GetComponent<PlayerHealth>();
            healthComponent.takeDamage(1);
        }
    }
}
