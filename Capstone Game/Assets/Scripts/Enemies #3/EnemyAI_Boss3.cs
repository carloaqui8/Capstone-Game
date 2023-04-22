using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class EnemyAI_Boss3 : BehaviorTree.Tree
{
    public Transform[] points;
    public static float speed = 3f;
    public static float viewRange = 6f;
    public GameObject[] minions;
    public static float timeBetweenSummons = 2.5f;
    public static float timeBetweenSprays = 2f;

    public GameObject projectile;

    protected override Node CreateTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckRange(transform, viewRange),
                new RushX(transform, speed),
                new Selector(new List<Node>
                {
                    new ExtremeSpray(transform, projectile, timeBetweenSprays),
                    new SummonEnemy(transform, minions, timeBetweenSummons)
                })
            }),
            new IdlePatrol(transform, points, speed)
        });

        return root;
    }
}
