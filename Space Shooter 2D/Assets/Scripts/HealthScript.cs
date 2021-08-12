/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Script used by the player and Boss-enemies to display their health bar in the game. 
*/


using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient healthGradient; // For adding different colors of health 
    public Image fill;

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        fill.color = healthGradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;

        fill.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
