using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class EnemyAI_2G : BehaviorTree.Tree
{
    public Transform[] points;
    public static float speed = 2f;

    protected override Node CreateTree()
    {
        Node root = new PatrolNode(transform, points);

        return root;
    }
}
