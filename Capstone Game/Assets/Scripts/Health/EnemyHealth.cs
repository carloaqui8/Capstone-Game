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
}
