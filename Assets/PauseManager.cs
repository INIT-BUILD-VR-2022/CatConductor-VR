using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject Text;
    public TextMeshPro TM;


    public void Start()
    {
        
    }

    public void pauser()
    {
        if (Time.timeScale == 0)
        {
            TM.text = "Pause";
            Debug.Log("The game has resumed" + Time.timeScale);
            Time.timeScale = 1;
        }
        else if (Time.timeScale == 1)
        {
            TM.text = "Resume";
            Debug.Log("The game has paused" + Time.timeScale);
            Time.timeScale = 0;
        }
    }
}
