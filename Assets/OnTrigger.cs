using UnityEngine;

public class Coal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Furnace furnace = other.GetComponent<Furnace>(); // Assuming the furnace is the object with the Furnace script attached
        if (furnace != null)
        {
            furnace.StartBurning();
            Debug.Log("Coal added to furnace.");
            Destroy(gameObject); // Destroy the coal object after it's been used
        }
    }
}
