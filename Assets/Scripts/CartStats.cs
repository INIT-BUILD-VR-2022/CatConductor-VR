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
    [HideInInspector] public bool isProtected = false;

    public GameObject forcefield;

    public float invincFramesTime = 0;
    public bool immune = false;

    public Animator trainAnim;

    public AudioSource hitAudioSource;
    public AudioClip hitSound;
    public AudioClip protectSound;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            if(immune){
                return;
            }
            else if(isProtected){
                isProtected = false;
                forcefield.SetActive(false);
                hitAudioSource.PlayOneShot(protectSound);
            }
            else{
                hp -= 1; 
                currentHealth = hp;//reduce hp by 1
                healthBar.SetHealth(currentHealth);
                Debug.Log("HP: " + hp);

                trainAnim.Play("Base Layer.HitTrain");
                StartCoroutine(Recovery());

                if(collision.gameObject.tag == "HitBox")
                {
                    hitAudioSource.PlayOneShot(hitSound);
                    
                }

            
                if (hp <= 0)
                {
                    Destroy(collision.gameObject.GetComponent<Force>());
                }



                gameOverScript.CheckGameOver();
            }
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

    IEnumerator Recovery(){

        immune = true;
        trainAnim.SetBool("Immune", true);
        yield return new WaitForSeconds(invincFramesTime);
        immune = false;
        trainAnim.SetBool("Immune", false);
    }

}
