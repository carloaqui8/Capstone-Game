using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class EnemyAI_3G : BehaviorTree.Tree
{
    public Transform[] points;
    public static float speed = 2f;
    public static float viewRange = 6f;
    public static float jumpSpeed = 18f;

    public static float rushSpeed = 5f;

    protected override Node CreateTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckRange(transform, viewRange),
                new Rush(transform, rushSpeed),
                new Jump(transform, jumpSpeed)
            }),
            new IdlePatrol(transform, points, speed)
        });

        return root;
    }
}
