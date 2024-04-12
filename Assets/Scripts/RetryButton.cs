using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class RetryButton : MonoBehaviour
{

    public GameObject Right_Controller;
    public XRRayInteractor ray;
    public LineRenderer LR;
    public XRInteractorLineVisual LV;

    public void Start()
    {
        ray = Right_Controller.GetComponent<XRRayInteractor>();
        LR = Right_Controller.GetComponent<LineRenderer>();
        LV = Right_Controller.GetComponent<XRInteractorLineVisual>();
        ray.enabled = false;
        LR.enabled = false;
        LV.enabled = false;
    }


    public void OnRetryPressed()
    {
        //Reset time scale in case the game was paused
        Time.timeScale = 1;
        ray.enabled = true;
        LR.enabled = true;
        LV.enabled = true;


        //Reload the current scene to restart the game
        SceneManager.LoadScene("feel test");
    }
}
