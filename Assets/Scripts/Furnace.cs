using UnityEngine;
using System.Collections;

public class Furnace : MonoBehaviour
{
    public float burnTime = 15f; // Time in seconds the furnace burns with each coal

    public float currentBurnTime = 0f; // Current burn time
    public bool isBurning = false; // Flag to track if the furnace is burning

    private Coal coal; // Reference to the coal object
    private CardboardBurning cardboard;// reference to the cardboard object

    public float amountOfTimeAdded;

    public CartStats cartS;//Reference to the CartStats Script for modifying health accessibility

    public Timer timer;

    void Start()
    {
        coal = null; // Initialize coal reference to null
    }

    // Function to start the furnace burning
    public void StartBurning()
    {
        timer.timevalue += amountOfTimeAdded;
        
        StartCoroutine(Burn());
        
    }

    // Coroutine to handle the burning process
    IEnumerator Burn()
    {
        Debug.Log("HELP I'M BURNING");

        isBurning = true; // Set the furnace to burning state
        currentBurnTime = 0f; // Reset current burn time

        if (cardboard != null)
        {
            cartS.isProtected = true;
            cartS.forcefield.SetActive(true);
        }
        
        while (currentBurnTime < burnTime)
        {
            currentBurnTime += Time.deltaTime; // Increment the current burn time
            yield return null; // Wait for the next frame
        }
        // Fire has burned out
        isBurning = false; // Set the furnace to not burning state
        if (coal != null)
        {
            coal.OnBurningComplete(); // Call OnBurningComplete() of the coal object
        }
        if(cardboard != null)
        {
            cardboard.OnBurningComplete();//  Call OnBurningComplete() of the coal object
        }

    }

    // Function to set the coal reference
    public void SetCoalReference(Coal coalObject)
    {
        coal = coalObject;
    }

    // Function to set the cardboard reference
    public void SetCBReference(CardboardBurning CB)
    {
        cardboard = CB;
    }
}

