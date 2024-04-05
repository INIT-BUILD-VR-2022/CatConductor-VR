using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooChooTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip chooChooSound;
    public Transform speedTriggerTransform;

    private bool isWithinSpeedTrigger = false;
    private bool isLooping = false;
    public float loopStart = 0.3f;
    public float loopEnd = 0.4f;

    // Update is called once per frame
    void Update()
    {
        isWithinSpeedTrigger = speedTriggerTransform.GetComponent<Collider>().bounds.Contains(transform.position);

        // If the lever is within the speed trigger
        if (isWithinSpeedTrigger)
        {
            if (!isLooping)
            {
                StartLoop();
            }
        }
        else
        {
            if (isLooping)
            {
                StopLoop();
            }
        }
    }

    private void StartLoop()
    {
        if (audioSource != null && chooChooSound != null)
        {
            audioSource.clip = chooChooSound;
            audioSource.time = loopStart;
            audioSource.Play();
            audioSource.loop = true;
            isLooping = true;

            // Schedule the end of the loop
            Invoke("LoopSection", loopEnd - loopStart);
        }
    }

    private void LoopSection()
    {
        if (isWithinSpeedTrigger && isLooping)
        {
            // Restart from loop point
            audioSource.time = loopStart;
            Invoke("LoopSection", loopEnd - loopStart);
        }
    }

    private void StopLoop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        isLooping = false;
        CancelInvoke("LoopSection");
    }
}
