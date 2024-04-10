using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public AudioSource hitSound;
    public AudioSource breakSound;
    public AudioSource whistle;
    public AudioSource backgroundMusic;

    public Slider SFXS;
    public Slider musicS;

    // Start is called before the first frame update
    void Start()
    {
        //SFXS = GetComponentInChildren<Slider>(true);
        //musicS = GetComponentInChildren<Slider>(true);

        SFXS.value = 1f;
        musicS.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        hitSound.volume = breakSound.volume = whistle.volume = SFXS.value;
        backgroundMusic.volume = musicS.value;
        Debug.Log("The volume for SFX is : " + SFXS.value
            + "\nThe volume for Music is : " + musicS.value);
    }
}
