using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public CartStats cartStats;
    public CatSpawner catSpawner;
    public Timer timer;
    public Rigidbody rb;
    public AudioSource music;


    public void CheckGameOver()
    {
        if (cartStats.hp <= 0)
        {
            TriggerGameOverEffects(true);
        }
    }

    public void TriggerGameOverEffects(bool killed)
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
        
        //if a rock killed you, fling the train away
        if(killed)
        {
            StartCoroutine(Death());
        }else{
            //this slowdown looks a bit jank, it should be rotation slowing not the timescale
            StartCoroutine(SlowMotion());
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

    }


    private IEnumerator Death(){

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1;
        music.Stop();

        
        rb.isKinematic = false;
        rb.useGravity = true;
        GetComponent<Collider>().enabled = false; 

        Vector3 spinVector = new Vector3(50000.0f, 50000.0f, 50000.0f);
        Vector3 leftwardForce = new Vector3(0.0f, 5000.0f, -10000.0f); // Negative X direction
        float forceMagnitude = 1f; // Adjust this value to achieve the desired speed

            
        rb.AddForce(leftwardForce, ForceMode.Force);
        rb.AddTorque(spinVector, ForceMode.Force);
        

        yield return new WaitForSecondsRealtime(3f);
        //Probably replace this with a function that sets time scale to 1 but stops the rotation of the island, this looks sorta jank
        StartCoroutine(SlowMotion());
        
    }
}


    //animate the train flying off
    //look at the force script ^

    //instatiate a canvas in world space in front of the player

    //have the retry button close to the player and make it grabable

    //retry button feature = restart the instance

    //display score
