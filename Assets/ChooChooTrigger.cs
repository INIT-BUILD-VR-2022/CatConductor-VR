using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChooChooTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip chooChooSound;
    public Transform speedTriggerTransform;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the handle enters the trigger and the sound has not played yet
        if (other.transform == speedTriggerTransform && !hasPlayed)
        {
            if (audioSource != null && chooChooSound != null)
            {
                audioSource.PlayOneShot(chooChooSound);
                hasPlayed = true; // Prevent the sound from playing again until handle exits
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When the handle leaves the trigger, allow the sound to be played again
        if (other.transform == speedTriggerTransform)
        {
            hasPlayed = false;
        }
    }
}
