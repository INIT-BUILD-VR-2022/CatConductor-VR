using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.ParticleSystemModule;

public class LevelSlow : MonoBehaviour
{

    public rotation rotScript;
    //public Rotation rotScript; // Assuming Rotation is the correct class 

    public ParticleSystem brakeSparks;

    void Start()
    {
        Debug.Log("Lever Script");
    }

   
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        rotScript.SlowDownRotation();

        brakeSparks.Play();
    }

  
}


