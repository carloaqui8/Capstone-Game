using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class EnemyAI_2F : BehaviorTree.Tree
{
    public Transform[] points;
    public static float speed = 2f;
    public static float bulletSpeed = 5f;
    public static float viewRange = 5f;
    public static float timeBetweenAttacks = .75f;
    public GameObject projectile;

    protected override Node CreateTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckInRangeNode2(transform),
                new ShootAtTargetNode2(transform, projectile)
            }),
            new PatrolNode2(transform, points)
        });

        return root;
    }
}
