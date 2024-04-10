using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeTracks : MonoBehaviour
{

    public Cart_Move cartMove;


    // Start is called before the first frame update
    private void OnTriggerStay(Collider obj)
    {
        if (cartMove.canInput == true)
        {
            // Check if the collided object has the "LeftPlane" tag
            if (obj.gameObject.CompareTag("LeftSide"))
            {
                Debug.Log("Collided with Left Plane");
                // Add your functionality here for when the lever hits the left plane
                StartCoroutine(cartMove.CartSwitchLeft());
            }
            // Check if the collided object has the "RightPlane" tag
            else if (obj.gameObject.CompareTag("RightSide"))
            {
                Debug.Log("Collided with Right Plane");
                // Add your functionality here for when the lever hits the right plane
                StartCoroutine(cartMove.CartSwitchRight());
            }
        }
    }

    // Update is called once per frame
    

    

}
