using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject entity;
    public int maxHealth = 20;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        flashStart();

        if (currentHealth > 0)
        {
            //alive
         
        }
        else
        {
            //dedge
            Destroy(entity);
        }
    }

    void flashStart() {
        entity.GetComponent<SpriteRenderer>().color = Color.black;
        Invoke("flashStop", 0.15f);
    }
     void flashStop() {
        entity.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
