using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBurning : MonoBehaviour
{
    public Animator CBAnimator; // Reference to the burning animation
    public ParticleSystem smokeParticles; // Reference to the smoke particle system
    public ParticleSystem fireParticles; // Reference to the fire particle system

    public HealthBar HP;// Reference to the HealthBar script

  

    private bool isBurning = false; // Flag to track if the CB is burning

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("HELP I'M TRIGGERING THE COLLISION >:((((((");
        if (!isBurning)
        {
            Furnace furnace = other.GetComponent<Furnace>();
            
            if (furnace != null)
            {
                furnace.SetCBReference(this); // Pass a reference to the CB object
                furnace.StartBurning();
                Debug.Log("CB added to furnace.");
       
                
                CBAnimator.SetBool("Burning", true);


                // Activate the particle systems for fire and smoke
                if (smokeParticles != null)
                {
                    smokeParticles.Play();
                }
                if (fireParticles != null)
                {
                    fireParticles.Play();
                }
            }
        }
    }

    // Called when the furnace finishes burning
    public void OnBurningComplete()
    {
        // Stop the particle systems for fire and smoke
        if (smokeParticles != null)
        {
            smokeParticles.Stop();
        }
        if (fireParticles != null)
        {
            fireParticles.Stop();
        }

        // Destroy the CB object
        Destroy(gameObject);
    }

}
