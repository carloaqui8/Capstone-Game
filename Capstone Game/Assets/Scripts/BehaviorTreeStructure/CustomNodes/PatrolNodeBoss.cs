using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class PatrolNodeBoss : Node
{
    private Transform enemy;
    private Transform[] points;

    private int pointIndex = 0;

    public PatrolNodeBoss(Transform enemy, Transform[] points)
    {
        this.enemy = enemy;
        this.points = points;
    }

    public override NodeState Evaluate()
    {
        if (Vector2.Distance(enemy.position, points[pointIndex].position) < 0.1f)
        {
            enemy.position = points[pointIndex].position;
            pointIndex = (pointIndex + 1) % points.Length;
        }
        else
        {
            enemy.position = Vector2.MoveTowards(enemy.position, points[pointIndex].position, EnemyAI_Boss2.speed * Time.deltaTime);
            //enemy.LookAt(points[pointIndex].position);        //if i want the object to actually turn around
        }

        state = NodeState.RUNNING;
        return state;
    }
}
