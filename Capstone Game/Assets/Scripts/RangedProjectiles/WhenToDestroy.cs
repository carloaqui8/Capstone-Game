using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenToDestroy : MonoBehaviour
{
    public GameObject lemon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" ||
            collision.gameObject.tag == "Wall" ||
            collision.gameObject.tag == "Ceiling") {

            Destroy(lemon);
        }
        else if (collision.gameObject.tag == "Enemy") {
            //Damage Enemy
            var healthComponent = collision.GetComponent<EnemyHealth>();
            healthComponent.takeDamage(1);

            Destroy(lemon);
        }
    }

}
