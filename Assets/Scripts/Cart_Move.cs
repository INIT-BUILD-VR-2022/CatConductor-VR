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

    bool canInput = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {



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

    IEnumerator CartSwitchLeft() 
    {
        if (currentXPosition > maxLeftPositions)
        {
            canInput = false;
            currentXPosition--;
            transform.Translate(Vector3.left * 8f); // Move left by 4 units
            
            yield return new WaitForSeconds(.1f);
            canInput = true;
                
        }


    }

    IEnumerator CartSwitchRight()
    {

        if (currentXPosition < maxRightPositions)
        {
            canInput = false;
            currentXPosition++;
            transform.Translate(Vector3.right * 8f); // Move right by 4 units
            
            yield return new WaitForSeconds(.1f);
            canInput = true;

                
        }
        
    }


}
