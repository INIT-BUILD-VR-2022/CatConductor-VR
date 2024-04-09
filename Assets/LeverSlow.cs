using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.ParticleSystemModule;

public class LevelSlow : MonoBehaviour
{

    public rotation rotScript;
    //public Rotation rotScript; // Assuming Rotation is the correct class 

    public ParticleSystem brakeSparks;
    public ParticleSystem trainSparks;

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

        trainSparks.Play();
        brakeSparks.Play();
    }

    void OnTriggerExit(Collider other)
    {
        trainSparks.Stop();
        brakeSparks.Stop();
    }


}


