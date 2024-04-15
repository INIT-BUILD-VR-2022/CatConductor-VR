using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void quitButton()
    {
        Debug.Log("Bro is leaving the game!! ");
        
        Application.Quit();//Stop the normies (actual players' game)
    }
}
