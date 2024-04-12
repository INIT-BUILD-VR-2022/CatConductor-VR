using UnityEngine;

public class Coal : MonoBehaviour
{
    public Animator coalAnimator; // Reference to the burning animation
    public ParticleSystem smokeParticles; // Reference to the smoke particle system
    public ParticleSystem fireParticles; // Reference to the fire particle system

    private bool isBurning = false; // Flag to track if the coal is burning

    private void OnTriggerEnter(Collider other)
    {
        if (!isBurning)
        {
            Furnace furnace = other.GetComponent<Furnace>(); 
            if (furnace != null)
            {
                furnace.SetCoalReference(this); // Pass a reference to the coal object
                furnace.StartBurning();
                Debug.Log("Coal added to furnace.");
                
                coalAnimator.SetBool("Burning", true);


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

        // Destroy the coal object
        Destroy(gameObject);
    }

}
