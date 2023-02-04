using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(health);
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        healthBar.setHealth(health);

    }

    public void Die()
    {
        print("Game Over");
    }
}
