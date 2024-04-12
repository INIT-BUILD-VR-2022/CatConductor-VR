using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void quitButton()
    {
        Debug.Log("Bro is leaving the game!! ");
        UnityEditor.EditorApplication.isPlaying = false; // Should stop the Editor when pressed now too
        Application.Quit();//Stop the normies (actual players' game)
    }

    public void play()
    {
        SceneManager.LoadScene("feel test");
    }
}
