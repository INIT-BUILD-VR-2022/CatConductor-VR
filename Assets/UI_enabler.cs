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
    public float threshHold = .1f;
    public float negativeThreshold = -.2f;


    /*
     * for future reference Fire1 is the a button on the controllers
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
        Debug.Log(Input.GetAxis(input));
        if (Input.GetAxis(input) > threshHold)
        {
            handUI.enabled = true;
        }
        else if(Input.GetAxis(input) < negativeThreshold)
        {
            handUI.enabled = false;
        }
    }

}
