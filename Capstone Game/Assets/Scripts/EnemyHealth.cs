using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public GameObject entity;
    public int maxHealth = 20;
    public float currentHealth;
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
            if (entity.name == "Boss1")
            {
                SceneManager.LoadScene(2);
            }
            else if (entity.name == "Boss2")
            {
                SceneManager.LoadScene(3);
            }
            else if (entity.name == "Boss3")
            {
                SceneManager.LoadScene(4);
            }
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
