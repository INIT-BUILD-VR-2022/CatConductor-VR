using UnityEngine;
using UnityEngine.UI;

public class FurnaceUI : MonoBehaviour
{
    public Text timerText;
    public Furnace furnace; // Reference to the Furnace object

    void Update()
    {
        // Check if furnace reference is not null
        if (furnace != null)
        {
            // Check if furnace is burning
            if (furnace.isBurning)
            {
                timerText.text = "Burn Time: " + furnace.currentBurnTime.ToString("F1");
            }
            else
            {
                timerText.text = "Fire has burned out.";
            }
        }
        else
        {
            Debug.LogWarning("Furnace reference is not assigned in FurnaceUI.");
        }
    }
}
