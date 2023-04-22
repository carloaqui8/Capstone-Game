using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class ShootPlayer : Node
{
    private Transform enemy;
    private GameObject projectile;
    private float bulletSpeed;

    private float attackCooldown;

    public ShootPlayer(Transform transform, GameObject projectile, float bulletSpeed)
    {
        this.enemy = transform;
        this.projectile = projectile;
        this.bulletSpeed = bulletSpeed;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)getData("target");            //Used for chasing target

        Vector3 difference = target.position - enemy.position;      //Used for shooting at target
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        attackCooldown += Time.deltaTime;
        if (attackCooldown >= EnemyAI_2G.timeBetweenAttacks)
        {
            GameObject bullet = Object.Instantiate(projectile);

            bullet.transform.position = enemy.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            attackCooldown = 0;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}
