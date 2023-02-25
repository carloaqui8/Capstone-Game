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
            flashHeal();
        }
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
    void flashStart()
    {
        entity.GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("flashStop", 0.25f);
    }

    void flashHeal()
    {
        entity.GetComponent<SpriteRenderer>().color = Color.green;
        Invoke("flashStop", 0.25f);
    }
    void flashStop()
    {
        entity.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
