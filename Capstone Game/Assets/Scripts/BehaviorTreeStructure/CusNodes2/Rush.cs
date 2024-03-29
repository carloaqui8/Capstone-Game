using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Rush : Node
{
    private Transform enemy;
    private float rushSpeed;

    public Rush(Transform transform, float rushSpeed)
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

        Vector2 targetLocation = player.position;              //Take snapshot of where player is

        enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(player.position.x, 0), rushSpeed * Time.deltaTime);
        if (enemy.GetComponent<EnemyHealth>().currentHealth <= 10)
        {
            rushSpeed = 7f;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
