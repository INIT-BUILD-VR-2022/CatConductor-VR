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
        volumeSlider = GetComponentInChildren<Slider>();
        volumeSlider.value = .5f;

        settingPanel.SetActive(false);
    }

    void Update()
    {
        AudioListener.volume = volumeSlider.value;
        //Debug.Log("The volume is at: " + AudioListener.volume);
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1;
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

    public void play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Game");
    }
}
