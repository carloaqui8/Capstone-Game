using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class JumpSprayNode : Node
{
    private Transform enemy;
    private GameObject projectile;
    private float timeBetweenAttacks;
    private float attackCooldown = 0;
    private bool onGround = true;

    public JumpSprayNode(Transform transform, GameObject proj, float CD)
    {
        this.enemy = transform;
        this.projectile = proj;
        this.timeBetweenAttacks = CD;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)getData("target");
        if (target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        attackCooldown += Time.deltaTime;

        if (attackCooldown >= timeBetweenAttacks) {
            Jump();

            if (enemy.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                GameObject[] bullets = new GameObject[8];
                for (int i = 0; i < bullets.Length; i++)
                {
                    bullets[i] = Object.Instantiate(projectile);
                    bullets[i].transform.position = new Vector3(enemy.position.x, enemy.position.y, 0);
                }
                //bullets all around
                bullets[0].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * EnemyAI_Boss2.bulletSpeed;    //up
                bullets[1].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * EnemyAI_Boss2.bulletSpeed;   //up left
                bullets[2].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * EnemyAI_Boss2.bulletSpeed;   //left
                bullets[3].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * EnemyAI_Boss2.bulletSpeed;  //left down
                bullets[4].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * EnemyAI_Boss2.bulletSpeed;   //down
                bullets[5].GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * EnemyAI_Boss2.bulletSpeed;   //right down
                bullets[6].GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * EnemyAI_Boss2.bulletSpeed;    //right
                bullets[7].GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * EnemyAI_Boss2.bulletSpeed;    //up right
                attackCooldown = 0;
                onGround = true;
            }
        }
        state = NodeState.SUCCESS;
        return state;
    }

    void Jump()
    {
        if (onGround)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 18f);
            onGround = false;
        }
    }
}