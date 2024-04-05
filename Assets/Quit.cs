using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    //if button is not being properly interacted with, then check C manager to see whats wrong

    //TODO: make debuglog for method below, then if doesnt work check cManager

    public void goToMainMenu()
    {

        SceneManager.LoadScene("Main Menu");
    }
}
