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

        if (enemy.position.x > targetLocation.x)
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(-23f, 0), rushSpeed * Time.deltaTime);
        }
        else
        {
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(100, 0), rushSpeed * Time.deltaTime);
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
