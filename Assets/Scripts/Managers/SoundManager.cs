using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    protected AudioClip[] clips;
    public List<AudioClip> clipList;
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
        }
    }


    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        MainSoundValue = 1;
        SoundEffectValue = 1;
        clips = Resources.LoadAll<AudioClip>("Sound");
        for (int i = 0; i < clips.Length; i++)
        {
            clipList.Add(clips[i]);
        }
    }


    public void PlayMainSound()
    {
        audioSource.Play();
    }

    public AudioClip GetAudioClip()
    {
        return audioSource.clip;
    }

    public void PlaySoundShot(string name)
    {
        AudioClip tmp = clipList.Find(o => o.name == name);
        if (tmp != null)
            audioSource.PlayOneShot(tmp, mainSoundValue * soundEffectValue);
    }



}
