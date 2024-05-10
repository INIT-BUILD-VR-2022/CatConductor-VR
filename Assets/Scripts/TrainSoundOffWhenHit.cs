using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSoundOffWhenHit : MonoBehaviour
{
    private AudioSource trainAudioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        trainAudioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }

  
}
