using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CartStats : MonoBehaviour
{
    public bool paused = false;
    public Timer timer;
    public int hp;
    [HideInInspector] public int score = 0;
    public float initialTime;
    public HealthBar healthBar;
    public int currentHealth;
    public GameOver gameOverScript;
    public bool isProtected = false;

    public GameObject forcefield;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            if (!isProtected)
            {
                hp -= 1;
                currentHealth = hp;//reduce hp by 1
                healthBar.SetHealth(currentHealth);
                Debug.Log("HP: " + hp);
            }
            else
            {
                isProtected = false;
                forcefield.SetActive(false);
            }

            if (hp <= 0)
            {
                Destroy(collision.gameObject.GetComponent<Force>());
            }
            gameOverScript.CheckGameOver();
        }
    }


    private void Start()
    {
        currentHealth = hp;
        Debug.Log("HP: " + hp);
        healthBar.SetMaxHealth(hp);

        if (timer != null)
        {
            timer.timevalue = initialTime;
        }
    }

}
