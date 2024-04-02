using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public CartStats cartStats;
    public CatSpawner catSpawner;
    public Timer timer;

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

    public void TriggerGameOverEffects()
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

        //Start the slow-motion effect
        StartCoroutine(SlowMotion());

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            Vector3 leftwardForce = new Vector3(0f, 1f, -1f); // Negative X direction
            float forceMagnitude = 2f; // Adjust this value to achieve the desired speed

            // Apply the force, multiplied by the desired magnitude
            rb.AddForce(leftwardForce.normalized * forceMagnitude, ForceMode.VelocityChange);
        }
    }

    private IEnumerator SlowMotion()
    {
        for (float t = 0; t < 2f; t += Time.unscaledDeltaTime)
        {
            Time.timeScale = Mathf.Lerp(1f, 0.1f, t / 2f);
            yield return null;
        }

        Time.timeScale = 0;

        FreezeRigidbodies();
    }

    private void FreezeRigidbodies()
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}


    //animate the train flying off
    //look at the force script ^

    //instatiate a canvas in world space in front of the player

    //have the retry button close to the player and make it grabable

    //retry button feature = restart the instance

    //display score
