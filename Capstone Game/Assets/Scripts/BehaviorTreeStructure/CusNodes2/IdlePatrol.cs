using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class IdlePatrol : Node
{
    private Transform enemy;
    private Transform[] points;
    private float moveSpeed;

    private int pointIndex = 0;

    public IdlePatrol(Transform enemy, Transform[] points, float moveSpeed)
    {
        this.enemy = enemy;
        this.points = points;
        this.moveSpeed = moveSpeed;
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
            enemy.position = Vector2.MoveTowards(enemy.position, points[pointIndex].position, moveSpeed * Time.deltaTime);
            //enemy.LookAt(points[pointIndex].position);        //if i want the object to actually turn around
        }

        state = NodeState.RUNNING;
        return state;
    }
}
