using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public EnemyAI_Boss1 theBoss;
    public Transform entrance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            theBoss.playerInRange = true;
            entrance.transform.position = new Vector2(entrance.transform.position.x, 0);
        }
    }
}
