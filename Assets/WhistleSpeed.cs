using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleSpeed : MonoBehaviour
{

    public rotation rotScript;
    public AudioSource audioSource;
    public AudioClip chooChooSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        rotScript.SpeedUpRotation();
        
    }

    void OnTriggerEnter(Collider other) {
        audioSource.PlayOneShot(chooChooSound);
    }
}

