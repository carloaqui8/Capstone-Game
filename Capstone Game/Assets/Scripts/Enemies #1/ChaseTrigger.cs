using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public EnemyAI_1F[] enemyArray;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(EnemyAI_1F enemy in enemyArray)
            {
                enemy.playerInRange = true;
            }
        }
    }
}
