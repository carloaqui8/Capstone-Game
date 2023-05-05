using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI_Boss1 : MonoBehaviour
{
    private GameObject player;
    public GameObject enemyLemon;
    public bool playerInRange = false;
    public float moveSpeed = 1;
    public float jumpSpeed;
    public float bulletSpeed;
    public float timeBetweenStomps = 3.5f,
                 timeBetweenBangs = 2;
    private float stompCD = 0,
                  projCD = 0;
    private bool inAir = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerInRange == true) {
            ChasePlayer();

            stompCD += Time.deltaTime;
            projCD += Time.deltaTime;

            if (stompCD >= timeBetweenStomps)
            {
                StompAttack();
            }

            if (projCD >= timeBetweenBangs)
            {
                ProjAttack();
            }
        }
        else { }
    }

    private void ChasePlayer() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private void StompAttack() {
        //do this
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(player.transform.position.x - transform.position.x, jumpSpeed);
        inAir = true;
        
        stompCD = 0;
    }

    private void ProjAttack() {
        //do this
        GameObject[] bullets = new GameObject[5];
        for (int i = 0; i < bullets.Length; i++) {
            bullets[i] = Instantiate(enemyLemon);
            bullets[i].transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
        }

        bullets[0].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * bulletSpeed;
        bullets[1].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * bulletSpeed;
        bullets[2].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * bulletSpeed;
        bullets[3].GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1) * bulletSpeed;
        bullets[4].GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * bulletSpeed;

        projCD = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            inAir = false;
        }

        if (collision.gameObject.tag == "Player" && inAir == true) {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2);
        }
    }
}
