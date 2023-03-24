using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class ShootAtTargetNodeBoss : Node
{
    private Transform enemy;
    private GameObject projectile;
    private float attackCooldown;

    public ShootAtTargetNodeBoss(Transform transform, GameObject projectile)
    {
        this.enemy = transform;
        this.projectile = projectile;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)getData("target");            //Used for chasing target

        Vector3 difference = target.position - enemy.position;      //Used for shooting at target
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Vector2.Distance(enemy.position, target.position) > 0.01f)
        {
            enemy.position = Vector2.MoveTowards(enemy.position, target.position, EnemyAI_Boss2.speed * Time.deltaTime);
        }

        attackCooldown += Time.deltaTime;
        if (attackCooldown >= EnemyAI_Boss2.timeBetweenAttacks)
        {
            GameObject bullet = Object.Instantiate(projectile) as GameObject;

            bullet.transform.position = enemy.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            bullet.GetComponent<Rigidbody2D>().velocity = direction * EnemyAI_Boss2.bulletSpeed;
            attackCooldown = 0;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
