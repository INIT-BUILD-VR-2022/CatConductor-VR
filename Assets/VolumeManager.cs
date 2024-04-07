using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();    
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volumeSlider.value; 
    }
}
