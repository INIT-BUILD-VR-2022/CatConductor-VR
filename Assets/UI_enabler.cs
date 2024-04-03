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

    private string input = "Vertical";
    /*
     * for future reference Fire1 is the x button on the controllers
     */

    //TODO:
    /*
     * Ensure that the scale is equal to the ratio in the main scene (normal scale is 40) so do .04
     * find way to get input for the ui enabling
     * add functinality to buttons in the menu
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        controllerHandL = Left_Controller.GetComponentInParent<Transform>();
        handUI = handUI.GetComponent<Canvas>();
        handUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetButton(input));
        if (Input.GetButtonDown(input))
        {
            Debug.Log("The button was pressed");

            if (handUI.enabled == true)
            {
                handUI.enabled = false;
                Debug.Log("The UI was disabled");
            }
            else if (handUI.enabled == false)
            {
                handUI.enabled = true;
                Debug.Log("The UI was enabled");
            }
        }
    }
}
