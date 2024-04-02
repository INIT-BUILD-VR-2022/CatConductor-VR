using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public CartStats cartStats;
    public CatSpawner catSpawner;

    Vector3 ImpulseVector = new Vector3(-1, 1, -1);
    Vector3 spinVector = new Vector3(-1, 1, -1);

    private void Update()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (cartStats.hp <= 0)
        {
            TriggerGameOverEffects();
        }
    }

    private void TriggerGameOverEffects()
    {
        //Disable CatSpawner Script
        if(catSpawner != null)
        {
            catSpawner.enabled = false;
        }

        // Display game over screen if assigned
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            rb.AddForce(ImpulseVector, ForceMode.Impulse);
            rb.AddTorque(spinVector, ForceMode.Impulse);
        }
    }
}


    //animate the train flying off
    //look at the force script ^

    //instatiate a canvas in world space in front of the player

    //have the retry button close to the player and make it grabable

    //retry button feature = restart the instance

    //display score
