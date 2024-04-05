using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip brakeSound;
    public Transform slowTriggerTransform;

    private bool isWithinSlowTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if (slowTriggerTransform != null && audioSource != null && brakeSound != null)
        {
            isWithinSlowTrigger = slowTriggerTransform.GetComponent<Collider>().bounds.Contains(transform.position);

            if (isWithinSlowTrigger && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(brakeSound);
            }
        }
    }
}
