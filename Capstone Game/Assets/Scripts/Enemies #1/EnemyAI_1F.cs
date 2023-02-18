using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1F : MonoBehaviour
{
    public float speed;
    public bool playerInRange = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerInRange == true || GetComponent<EnemyHealth>().currentHealth != GetComponent<EnemyHealth>().maxHealth) {
            ChasePlayer();
        }
        else { }
    }

    void ChasePlayer() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
