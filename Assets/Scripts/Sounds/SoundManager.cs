using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    public SoundType[] Sounds;
    public bool isMute = false;
    public float sfxVolume = 1f;
    public float musicVolume = 0.7f;
 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetsfxVolume(0.8f);
        SetMusicVolume(0.5f);
        PlayMusic(global::Sounds.Music);
        
    }

    public void Mute(bool status)
    {
        isMute = status;
    }
    public void SetsfxVolume(float volume)
    {
        sfxVolume = volume;
        soundEffect.volume = sfxVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        soundMusic.volume = musicVolume;
    }

    public void PlayMusic(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for Soundtype: " + sound);
        }
    }
    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for Soundtype: " + sound);
        }

    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item  = Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    RestartButtonclick,
    EnemyImpact,
    ButtonLocked,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}
