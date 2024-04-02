using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class UI_enabler : MonoBehaviour
{

    Transform controllerHandL;
    public GameObject Left_Controller;
    public Canvas handUI;
    Vector3 controllerPosition;
    Vector3 player_Head;

    //TODO:
    /*
     * Ensure that the scale is equal to the ratio in the main scene (normal scale is 40) so do .04
     * find better solution to ui enabling 
     * add functinality to buttons in the menu
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        controllerHandL = Left_Controller.GetComponentInParent<Transform>();
        handUI = handUI.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(controllerHandL.rotation.x >= 0)
        {
            handUI.enabled =true;
        }
        else
        {
            handUI.enabled = false;
        }
    }
}
