using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject entity;
    public int maxHealth = 20;
    public int currentHealth;
    public int timeBetweenRegens = 10;
    private float regenCD;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        regenCD += Time.deltaTime;

        if (regenCD >= timeBetweenRegens) {
            currentHealth += 1;
            regenCD = 0;
        }
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
