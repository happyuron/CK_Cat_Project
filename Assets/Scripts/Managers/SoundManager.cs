using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;
    public float mainSoundValue { get; set; }

    public float soundEffectValue { get; set; }


    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        mainSoundValue = 1;
        soundEffectValue = 1;
    }

    public void PlayMainSound()
    {
        audioSource.Play();
    }

    public static void PlaySoundShot()
    {

    }


    private void Update()
    {
        audioSource.volume = mainSoundValue;
    }


}
