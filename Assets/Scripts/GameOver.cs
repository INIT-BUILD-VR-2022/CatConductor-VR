using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public CartStats cartStats;
    public CatSpawner catSpawner;
    public Timer timer;
    public Rigidbody rb;
    public AudioSource music;
    public rotation rotation;
    private float slowDownRate;
    public bool IsGameover = false;


    public XRRayInteractor ray;
    public LineRenderer LR;
    public XRInteractorLineVisual LV;

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
        }
        
        rotation.SlowDownRotationToZero();
        IsGameover = true;

        ray.enabled = true;
        LR.enabled = true;
        LV.enabled = true;

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
        
        
    }
}

    


    //animate the train flying off
    //look at the force script ^

    //instatiate a canvas in world space in front of the player

    //have the retry button close to the player and make it grabable

    //retry button feature = restart the instance

    //display score
