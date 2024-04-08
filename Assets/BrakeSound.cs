using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip brakeSound;
    public Transform slowTriggerTransform;


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == slowTriggerTransform && audioSource != null && brakeSound != null && !audioSource.isPlaying)
        {
            audioSource.clip = brakeSound;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform == slowTriggerTransform)
        {
            audioSource.Stop();
        }
    }
}
