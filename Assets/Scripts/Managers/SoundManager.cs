using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip[] clips = Resources.LoadAll("Resources/Sound") as AudioClip[];
    public AudioSource audioSource;
    public float MainSoundValue { get; set; }

    public float SoundEffectValue { get; set; }


    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        MainSoundValue = 1;
        SoundEffectValue = 1;
    }

    public void PlayMainSound()
    {
        audioSource.Play();
    }

    public void PlaySoundShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, MainSoundValue * SoundEffectValue);

    }


    private void Update()
    {
        audioSource.volume = MainSoundValue;
    }


}
