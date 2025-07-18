using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    public int TakeDamage(int damage, int currentHealth)
    {
        currentHealth -= damage;

        setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("FailurePopUp");
        }

        return currentHealth;
    }


}
