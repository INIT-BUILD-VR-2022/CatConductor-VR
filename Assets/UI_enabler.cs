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
