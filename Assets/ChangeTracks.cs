/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeTracks : MonoBehaviour
{

    public Cart_Move cartMove;
    public Animator SM_Veh_Train_01_Bell;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider obj)
    {
        if (cartMove.canInput == true)
        {
            // Check if the collided object has the "LeftPlane" tag
            if (obj.gameObject.CompareTag("LeftSide"))
            {
                Debug.Log("Collided with Left Plane");
                StartCoroutine(cartMove.CartSwitchLeft());
                SM_Veh_Train_01_Bell.SetBool("RingLeft", true);

            }
            // Check if the collided object has the "RightPlane" tag
            else if (obj.gameObject.CompareTag("RightSide"))
            {
                Debug.Log("Collided with Right Plane");
                StartCoroutine(cartMove.CartSwitchRight());
                SM_Veh_Train_01_Bell.SetBool("RingRight", true);
            }
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        // Reset animation booleans when the lever exits the side triggers
        if (obj.CompareTag("LeftSide"))
        {
            SM_Veh_Train_01_Bell.SetBool("RingLeft", false);
        }
        else if (obj.CompareTag("RightSide"))
        {
            SM_Veh_Train_01_Bell.SetBool("RingRight", false);
        }
    }


}
*/

using System.Collections;
using UnityEngine;

public class ChangeTracks : MonoBehaviour
{
    public Cart_Move cartMove;
    private Animator leftBellAnimator;
    private Animator rightBellAnimator;

    private void Start()
    {
        // Assuming the bell is a direct child of the collider game objects
        leftBellAnimator = GameObject.FindGameObjectWithTag("LeftSide").GetComponentInChildren<Animator>();
        rightBellAnimator = GameObject.FindGameObjectWithTag("RightSide").GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!cartMove.canInput) return;

        if (other.CompareTag("LeftSide"))
        {
            Debug.Log("Lever entered Left Trigger");
            // Trigger the bell animation
            leftBellAnimator.SetTrigger("Ring");
            // Additional functionality
            StartCoroutine(cartMove.CartSwitchLeft());
        }
        else if (other.CompareTag("RightSide"))
        {
            Debug.Log("Lever entered Right Trigger");
            // Trigger the bell animation
            rightBellAnimator.SetTrigger("Ring");
            // Additional functionality
            StartCoroutine(cartMove.CartSwitchRight());
        }
    }
}
