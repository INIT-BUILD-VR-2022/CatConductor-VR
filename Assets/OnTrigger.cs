using UnityEngine;

public class Coal : MonoBehaviour
{
    public Animation burningAnimation; // Reference to the burning animation
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
                isBurning = true; 

                // Start the burning animation when the coal enters the furnace
                if (burningAnimation != null)
                {
                    burningAnimation.Play();
                }

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

        // Stop the burning animation
        if (burningAnimation != null)
        {
            burningAnimation.Stop();
        }

        // Destroy the coal object
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (isBurning)
        {
            // If the coal is burning, stop the particle systems and animation when it exits the furnace
            if (smokeParticles != null)
            {
                smokeParticles.Stop();
            }
            if (fireParticles != null)
            {
                fireParticles.Stop();
            }
            if (burningAnimation != null)
            {
                burningAnimation.Stop();
            }
        }

        // If the coal is not burning anymore and it exits the furnace collider, destroy it
        Destroy(gameObject);
    }
}
