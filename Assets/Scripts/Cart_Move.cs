using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Move : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5f;
    public int maxLeftPositions = -1; // Set the maximum left positions
    public int maxRightPositions = 1; // Set the maximum right positions
    private int currentXPosition = 0; // Tracks the current position
    public AudioSource switchtrack;
    public AudioClip switchsound; 

    //public Animator trainAnim;

    //public rotation rotScript;

    public bool canInput = true;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //trainAnim.speed = rotScript.rotationSpeed; 

        // Move Left
        if (Input.GetKey(KeyCode.A) && canInput)
        {
            StartCoroutine(CartSwitchLeft());

        }

        // Move Right
        if (Input.GetKey(KeyCode.D) && canInput)
        {
            StartCoroutine(CartSwitchRight());
        }
        //Look into making the positions into an array and switch positions

    }

    public IEnumerator CartSwitchLeft() 
    {
        if (currentXPosition > maxLeftPositions)
        {
            canInput = false;
            currentXPosition--;
            transform.Translate(Vector3.left * 4f); // Move left by 4 units

            switchtrack.PlayOneShot(switchsound);

            yield return new WaitForSeconds(.3f);
            canInput = true;
            
                
        }


    }

    public IEnumerator CartSwitchRight()
    {

        if (currentXPosition < maxRightPositions)
        {
            canInput = false;
            currentXPosition++;
            transform.Translate(Vector3.right * 4f); // Move right by 4 units

            switchtrack.PlayOneShot(switchsound);
            yield return new WaitForSeconds(.3f);
            canInput = true;

                
        }
        
    }


}
