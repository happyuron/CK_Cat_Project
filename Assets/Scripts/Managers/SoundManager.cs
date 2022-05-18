using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip[] clips;
    public AudioSource audioSource;
    private float mainSoundValue;
    private float soundEffectValue;
    public float MainSoundValue
    {
        get { return mainSoundValue; }
        set
        {
            mainSoundValue = value;
            audioSource.volume = mainSoundValue;
        }
    }

    public float SoundEffectValue
    {
        get { return soundEffectValue; }
        set
        {
            soundEffectValue = value;
            audioSource.volume = soundEffectValue;
        }
    }



    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        MainSoundValue = 1;
        SoundEffectValue = 1;
        clips = Resources.LoadAll("Resources/Sound") as AudioClip[];
    }

    public void PlayMainSound()
    {
        audioSource.Play();
    }

    public AudioClip GetAudioClip()
    {
        return audioSource.clip;
    }

    public void PlaySoundShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip, MainSoundValue * SoundEffectValue);
    }



}
