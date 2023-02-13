using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehavior : MonoBehaviour
{
    public GameObject proj;
    public int damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||
            collision.gameObject.tag == "Wall" ||
            collision.gameObject.tag == "Ceiling")
        {

            Destroy(proj);
        }
        else if (collision.gameObject.tag == "Player")
        {
            //Damage Player
            var healthComponent = collision.GetComponent<PlayerHealth>();
            healthComponent.takeDamage(damageAmount);

            Destroy(proj);
        }
        else { }
    }
}
