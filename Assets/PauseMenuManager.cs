using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{

    public GameObject settingPanel;
    public GameObject pausePanel;
    Slider volumeSlider;

    private void Start()
    {
        /*settingPanel = GameObject.Find("SettingPanel");
        if(settingPanel == null)
        {
            Debug.Log("setting pannel was not found!!");
        }*/
        volumeSlider = GetComponentInChildren<Slider>();
        settingPanel.SetActive(false);
    }

    void Update()
    {
        AudioListener.volume = volumeSlider.value;
        Debug.Log("The volume is at: " + AudioListener.volume);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void goToSettings()
    {
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void goToPauseMenu()
    {
        pausePanel.SetActive(true);
        settingPanel.SetActive(false);
    }
}
