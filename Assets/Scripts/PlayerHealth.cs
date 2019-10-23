using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public Slider HealthSlider;
    public Image DamageImage;
    public Color FlashColour = new Color(1f, 0f, 0f, 0.1f);
    public float FlashSpeed = 5f;

    private int currentHealth;
    private bool isDamaged;

    public void Awake()
    {
        currentHealth = MaxHealth;
        isDamaged = false;
        HealthSlider.value = MaxHealth;
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }

    public void Damage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }

        if (currentHealth < damage)
        {
            currentHealth = 0;
        } else
        {
            currentHealth = currentHealth - damage;
        }
        HealthSlider.value = currentHealth;
        isDamaged = true;
    }

    public void Heal(int health)
    {
        if (health <= 0)
        {
            return;
        }

        if (currentHealth + health > MaxHealth)
        {
            currentHealth = MaxHealth;
        } else
        {
            currentHealth = currentHealth + health;
        }
        HealthSlider.value = currentHealth;
    }

    void Update()
    {
        if (isDamaged)
        {
            DamageImage.color = FlashColour;
        }
        else
        {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, FlashSpeed * Time.deltaTime);
        }

        isDamaged = false;
    }
}
