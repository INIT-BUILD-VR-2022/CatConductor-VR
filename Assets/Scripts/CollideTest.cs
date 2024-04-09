using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTest : MonoBehaviour
{
    public AudioSource lol;
    private void Start()
    {
        lol.loop = true;
    }
    void OnCollisionEnter(Collision other)
    {
       
        print(other.gameObject);
        
    }
    private void Update()
    {
        if (!lol.isPlaying)
        {
            lol.Play();
        }
    }
}
