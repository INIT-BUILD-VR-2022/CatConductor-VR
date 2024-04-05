using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooChooTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip chooChooSound;
    public Transform speedTriggerTransform;

    private bool isWithinSpeedTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (speedTriggerTransform != null && audioSource != null && chooChooSound != null)
        {
            isWithinSpeedTrigger = speedTriggerTransform.GetComponent<Collider>().bounds.Contains(transform.position);
            
            if (isWithinSpeedTrigger && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(chooChooSound);
            }
        }        
    }
}
