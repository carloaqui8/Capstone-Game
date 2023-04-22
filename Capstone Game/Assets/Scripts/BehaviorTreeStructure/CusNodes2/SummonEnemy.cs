using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class SummonEnemy : Node
{
    private Transform enemy;
    private GameObject[] minions;
    private float timeBetweenSummons;

    private float summonCD = 0f;
    private int index = 0;
    public SummonEnemy(Transform transform, GameObject[] minions, float timeBetweenSummons)
    {
        this.enemy = transform;
        this.minions = minions;
        this.timeBetweenSummons = timeBetweenSummons;
    }

    public override NodeState Evaluate()
    {
        Transform player = (Transform)getData("target");

        if (player == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (enemy.GetComponent<EnemyHealth>().currentHealth <= 25)
        {
            state = NodeState.FAILURE;
            return state;
        }

        summonCD += Time.deltaTime;

        if (summonCD >= timeBetweenSummons)
        {
            GameObject minion = GameObject.Instantiate(minions[index % 4]);
            if (player.position.x < enemy.position.x)
            {
                minion.transform.position = new Vector3(enemy.position.x - 4, enemy.position.y + 2);
            }
            else
            {
                minion.transform.position = new Vector3(enemy.position.x + 4, enemy.position.y + 2);
            }

            index++;
            summonCD = 0;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
