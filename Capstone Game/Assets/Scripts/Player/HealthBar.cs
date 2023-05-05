using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image totalHealth;
    public Image currentHealth;

    void Start()
    {
        totalHealth.fillAmount = playerHealth.currentHealth / 20;
    }

    void Update()
    {
        currentHealth.fillAmount = playerHealth.currentHealth / 20;
    }
}
