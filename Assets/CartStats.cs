using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartStats : MonoBehaviour
{
    public bool paused = false;
    public int hp;
    public float time;

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
    }
    private void Update()
    {
        
    }


}
