using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class RetryButton : MonoBehaviour
{
    public void OnRetryPressed()
    {
        //Reset time scale in case the game was paused
        Time.timeScale = 1;

        //Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
