using UnityEngine;

public class Coal : MonoBehaviour
{
    private bool isBurning = false; // Flag to track if the furnace is burning

    private void OnTriggerEnter(Collider other)
    {
        Furnace furnace = other.GetComponent<Furnace>(); 
        if (furnace != null)
        {
            furnace.SetCoalReference(this); // Pass a reference to the coal object
            furnace.StartBurning();
            Debug.Log("Coal added to furnace.");
            isBurning = true; 
        }
    }

    // Called when the furnace finishes burning
    public void OnBurningComplete()
    {
        // Destroy the coal object
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (isBurning)
        {
            // If the coal is burning, don't destroy it immediately
            return;
        }

        // If the coal is not burning anymore and it exits the furnace collider, destroy it
        Destroy(gameObject);
    }
}


