using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class DodgeF : Node
{
    private Transform enemy;
    private float dodgeSpeed;
    private float timeBetweenDodges;
    private float dodgeCooldown = 2;

    private int index = 0;
    public DodgeF(Transform transform, float dodgeSpeed, float timeBetweenDodges)
    {
        this.enemy = transform;
        this.dodgeSpeed = dodgeSpeed;
        this.timeBetweenDodges = timeBetweenDodges;
    }

    public override NodeState Evaluate()
    {
        Transform player = (Transform)getData("target");

        if (player == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (enemy.GetComponent<EnemyHealth>().currentHealth <= 10)
        {
            state = NodeState.FAILURE;
            return state;
        }

        dodgeCooldown += Time.deltaTime;

        if (Input.GetMouseButton(1) && dodgeCooldown >= timeBetweenDodges)
        {
            if (index % 2 == 0)
            {
                enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(dodgeSpeed, enemy.GetComponent<Rigidbody2D>().velocity.y);
                index = 1;
            }
            else
            {
                enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-dodgeSpeed, enemy.GetComponent<Rigidbody2D>().velocity.y);
                index = 0;
            }
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
