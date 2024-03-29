using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour
{
    public float burnTime = 10f; // Time in seconds the furnace burns with each coal

    public float currentBurnTime = 0f; // Current burn time
    public bool isBurning = false; // Flag to track if the furnace is burning

    private Coal coal; // Reference to the coal object

    void Start()
    {
        coal = null; // Initialize coal reference to null
    }

    // Function to start the furnace burning
    public void StartBurning()
    {
        if (!isBurning)
        {
            StartCoroutine(Burn());
        }
    }

    // Coroutine to handle the burning process
    IEnumerator Burn()
    {
        isBurning = true; // Set the furnace to burning state
        currentBurnTime = 0f; // Reset current burn time
        while (currentBurnTime < burnTime)
        {
            currentBurnTime += Time.deltaTime; // Increment the current burn time
            Debug.Log("Current Burn Time: " + currentBurnTime); // Log the current burn time
            yield return null; // Wait for the next frame
        }
        // Fire has burned out
        isBurning = false; // Set the furnace to not burning state
        if (coal != null)
        {
            coal.OnBurningComplete(); // Call OnBurningComplete() of the coal object
        }
    }

    // Function to set the coal reference
    public void SetCoalReference(Coal coalObject)
    {
        coal = coalObject;
    }
}

