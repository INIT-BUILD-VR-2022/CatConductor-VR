using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumpsounds : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audio;
    public float hitspeed = 3f;

    public AnimationCurve soundVSspeedCurve;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > 0.01f && collision.relativeVelocity.magnitude <= hitspeed)
        {
            audio.volume = 0.1f;
            audio.Play();
            audio.volume = 1f;
        }

        if (collision.relativeVelocity.magnitude > hitspeed)
        {
            audio.Play();
        }
        
    }
}
