using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class EnemyAI_3F : BehaviorTree.Tree
{
    public Transform[] points;
    public static float speed = 3f;
    public static float viewRange = 6f;
    public static float dodgeSpeed = 10f;
    public static float timeBetweenAttacks = 1.5f;
    private static float timeBetweenDodges = 2f;
    public GameObject projectile;

    protected override Node CreateTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckRange(transform, viewRange),
                new Sequence(new List<Node>
                {
                    new Rush(transform, speed),
                    new Selector(new List<Node>
                    {
                        new DodgeF(transform, dodgeSpeed, timeBetweenDodges),
                        new Spray(transform, projectile, timeBetweenAttacks)
                    })
                })
            }),
            new IdlePatrol(transform, points, speed)
        });

        return root;
    }
}
