using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject Cat;
    private Vector3 originalCatPosition;
    //How far the Cat has to be from the Seat to spawn a new one
    public float spawnThresholdDistance = 5f;

    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        //Variable to hold the Cat's position
        originalCatPosition = Cat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning) return; //Check if we're already in the process of spawning a cat

        //This calculates the distance of the cat to the seat, is then stored into the distance variable
        float distance = Vector3.Distance(Cat.transform.position, transform.position);


        //if the distance is greater than the threshold, we spawn a new cat using the SpawnNewCat() method
        if (distance > spawnThresholdDistance && !isSpawning)
        {
            Debug.Log("Distance threshold exceeded, spawning new cat cube.");
            StartCoroutine(SpawnNewCat());
        }  
    }

    IEnumerator SpawnNewCat()
    {
        isSpawning = true; //prevents spawning new cats while already spawning one

        yield return new WaitForSeconds(2f); //Wait for 2 seconds before spawning the cat

        //Create new cat
        GameObject newCat = Instantiate(Cat, originalCatPosition, Quaternion.identity);

        //Update the Cat reference
        Cat = newCat;

        isSpawning = false;
    }
}
