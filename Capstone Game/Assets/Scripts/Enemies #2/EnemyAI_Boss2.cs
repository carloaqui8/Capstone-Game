using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class EnemyAI_Boss2 : BehaviorTree.Tree
{
    public Transform[] points;
    public static float speed = 2f;
    public static float bulletSpeed = 15f;
    public static float timeBetweenAttacks = 1.5f;
    public static float viewRange = 6f;
    public GameObject projectile;

    public static float timeBetweenRushs = 5f;
    public static float timeBetweenSprays = 3f;
    public static float rushDistance = 2f;

    protected override Node CreateTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckInRangeNodeBoss(transform),
                new ShootAtTargetNodeBoss(transform, projectile),
                new RushTargetNode(transform, timeBetweenRushs),
                new JumpSprayNode(transform, projectile, timeBetweenSprays)
            }),
            new PatrolNodeBoss(transform, points)
        });

        return root;
    }
}
