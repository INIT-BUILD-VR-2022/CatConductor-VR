using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiegeticHealth : MonoBehaviour
{
    public GameObject[] bulbs;
    private int maxhealth = 3;
    private int health = 3;
    
    // This script is meant to drive a diagetic health meter using light bulbs.
    // - Christopher Woodhouse
    void Start()
    {
        
    }

    public void SetHealth(int i)
    {
        



        AdjustDisplay();
    }

    void AdjustDisplay()
    {

    }

}
