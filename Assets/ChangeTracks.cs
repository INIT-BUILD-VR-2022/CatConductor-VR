using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTracks : MonoBehaviour
{

    public Camera playerCamera;
    public float moveSpeed = 5f;
    public int maxLeftPositions = -1; // Set the maximum left positions
    public int maxRightPositions = 1; // Set the maximum right positions
    private int currentXPosition = 0; // Tracks the current position

    bool canInput = true;

    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        // Check if the collided object has the "LeftPlane" tag
        if (collision.gameObject.CompareTag("LeftSide"))
        {
            Debug.Log("Collided with Left Plane");
            // Add your functionality here for when the lever hits the left plane
            StartCoroutine(CartSwitchLeft());
        }
        // Check if the collided object has the "RightPlane" tag
        else if (collision.gameObject.CompareTag("RightSide"))
        {
            Debug.Log("Collided with Right Plane");
            // Add your functionality here for when the lever hits the right plane
            StartCoroutine(CartSwitchRight());
        }
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

    IEnumerator CartSwitchLeft()
    {
        if (currentXPosition > maxLeftPositions)
        {
            canInput = false;
            currentXPosition--;
            transform.Translate(Vector3.left * 4f); // Move left by 4 units

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
            transform.Translate(Vector3.right * 4f); // Move right by 4 units

            yield return new WaitForSeconds(.1f);
            canInput = true;


        }

    }

}
