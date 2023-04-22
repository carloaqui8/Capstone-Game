using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class RushX : Node
{
    private Transform enemy;
    private float rushSpeed;

    public RushX(Transform transform, float rushSpeed)
    {
        this.enemy = transform;
        this.rushSpeed = rushSpeed;
    }

    public override NodeState Evaluate()
    {
        Transform player = (Transform)getData("target");

        if (player == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (enemy.position.x > player.position.x)
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(-23, 0), rushSpeed * Time.deltaTime);
        }
        else
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(100, 0), rushSpeed * Time.deltaTime);
        }
        if (enemy.GetComponent<EnemyHealth>().currentHealth <= 10)
        {
            rushSpeed = 7f;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}