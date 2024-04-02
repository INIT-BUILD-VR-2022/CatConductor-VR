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


    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("HitBox"))
        {
            hp -= 1; //reduce hp by 1
            Debug.Log("HP: " + hp);

            if (hp <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    private void Start()
    {
        Debug.Log("HP: " + hp);

        if (timer != null)
        {
            timer.timevalue = initialTime;
        }
    }

}
