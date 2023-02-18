using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1G : MonoBehaviour
{
    public GameObject whoToChase;
    public GameObject enemyLemon;
    public float moveSpeed = 1;
    public float jumpSpeed;
    public float bulletSpeed;
    public float timeBetweenJumps = 5,
                 timeBetweenAttacks = 2;
    private float jumpCD = 0,
                  attackCD = 0;

    // Update is called once per frame
    void Update()
    {
        jumpCD += Time.deltaTime;
        attackCD += Time.deltaTime;

        ChasePlayer();

        if (jumpCD >= timeBetweenJumps) {
            Jump();
        }

        if (attackCD >= timeBetweenAttacks) {
            Attack();
        }

    }

    void Jump() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        jumpCD = 0;
    }

    void Attack() {
        GameObject bullet = Instantiate(enemyLemon) as GameObject;                  //Creates bullet
        bullet.transform.position = transform.position;                             //Starting at Player

        if (whoToChase.transform.position.x > transform.position.x) {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * bulletSpeed;
        }
        else {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * bulletSpeed;
        }
        attackCD = 0;
    }
    void ChasePlayer() {
        transform.position = Vector2.MoveTowards(transform.position, whoToChase.transform.position, moveSpeed * Time.deltaTime);
    }
}