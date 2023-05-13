using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int respawnScene;
    public GameObject entity;
    public int maxHealth = 20;
    public float currentHealth;
    public int timeBetweenRegens = 10;
    private float regenCD;
    public Image currentHealthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = currentHealth / 20;
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
            currentHealth = maxHealth;
            SceneManager.LoadScene(respawnScene);
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
