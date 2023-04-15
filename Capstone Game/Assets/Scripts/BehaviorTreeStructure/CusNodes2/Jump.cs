using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Jump : Node
{
    private Transform enemy;
    private float jumpSpeed;

    private bool onGround = true;

    public Jump(Transform transform, float jumpSpeed)
    {
        this.enemy = transform;
        this.jumpSpeed = jumpSpeed;
    }

    public override NodeState Evaluate()
    {
        Transform player = (Transform)getData("target");

        if (player == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (player.GetComponent<PlayerMovement>().onGround == true)
        {
            onGround = true;
        }

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(enemy.GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
            onGround = false;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
