using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UI_enabler : MonoBehaviour
{
    public GameObject Left_Controller;
    public GameObject Right_Controller;
    public XRRayInteractor ray;
    public LineRenderer LR;
    public XRInteractorLineVisual LV;
    public Canvas handUI;
    public GameObject PausePanel;
    public GameObject SettingPanel;

    private string input = "Vertical";
    public float threshHold = .6f;
    public float negativeThreshold = -.6f;

    // Start is called before the first frame update
    void Start()
    {
        handUI = handUI.GetComponent<Canvas>();
        ray = Right_Controller.GetComponent<XRRayInteractor>();
        LR = Right_Controller.GetComponent<LineRenderer>();
        LV = Right_Controller.GetComponent<XRInteractorLineVisual>();
        handUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis(input));
        if (Input.GetAxis(input) > threshHold)
        {
            Time.timeScale = 0;
            handUI.enabled = true;
            ray.enabled = true;
            LR.enabled = true;
            LV.enabled = true;
        }
        else if(Input.GetAxis(input) < negativeThreshold)
        {
            Time.timeScale = 1;
            SettingPanel.SetActive(false);
            PausePanel.SetActive(true);
            handUI.enabled = false;
            ray.enabled = false;
            LR.enabled = false;
            LV.enabled = false;
        }
    }

}
