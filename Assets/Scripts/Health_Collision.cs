using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Collision : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;
   // public HealthBar healthBar;
   // public GameOver gameOverScript;

    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "HitBox")
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        //gameOverScript.CheckGameOver();
    }
}
