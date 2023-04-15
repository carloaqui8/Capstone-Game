using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class CheckRange : Node
{
    private Transform enemy;
    private float viewRange;

    public CheckRange(Transform transform, float viewRange)
    {
        this.enemy = transform;
        this.viewRange = viewRange;
    }

    public override NodeState Evaluate()
    {
        object player = getData("target");
        if (player == null)
        {
            Collider2D entity = Physics2D.OverlapCircle(enemy.position, viewRange, LayerMask.GetMask("Default"));
            if (entity != null)
            {
                if (entity.tag == "Player")
                {
                    parent.parent.setData("target", entity.transform);

                    state = NodeState.SUCCESS;
                    return state;
                }
            }
            else { }
            state = NodeState.FAILURE;
            return state;
        }
        else { }
        state = NodeState.SUCCESS;
        return state;
    }
}
