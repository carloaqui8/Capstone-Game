using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class CheckInRangeNode2 : Node
{
    private Transform enemy;

    public CheckInRangeNode2(Transform transform)
    {
        this.enemy = transform;
    }

    public override NodeState Evaluate()
    {
        object player = getData("target");
        if (player == null)
        {
            Collider2D entity = Physics2D.OverlapCircle(enemy.position, EnemyAI_2F.viewRange, LayerMask.GetMask("Default"));
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
