using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class RushTargetNode : Node
{
    private Transform enemy;
    private float timeBetweenAttacks;
    private float attackCooldown = 0;

    public RushTargetNode(Transform transform, float cooldown)
    {
        this.enemy = transform;
        this.timeBetweenAttacks = cooldown;
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
        attackCooldown += Time.deltaTime;

        if (Vector2.Distance(enemy.position, targetLocation) > 0.01f && attackCooldown >= timeBetweenAttacks)
        {
            enemy.position = Vector2.MoveTowards(enemy.position, targetLocation, EnemyAI_Boss2.rushDistance);
            attackCooldown = 0;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
