using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {get; private set;}
    public Sound[] audioMusic, audioSFX;
    public AudioSource musicSource, sfxSource;

    [Header("Variabel")]
    private float masterVolume = 1.0f;
    private float musicVolume = 1.0f;
    private float sfxVolume = 1.0f;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(audioMusic, x => x.name == name);
        PlayAudioClip(sound.clip, musicSource);
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(audioSFX, x => x.name == name);
        PlayAudioClip(sound.clip, sfxSource);
    }

    private void PlayAudioClip(AudioClip clip, AudioSource source)
    {
        if (clip == null)
        {
            Debug.Log("Sound Not Found");
            return;
        }
        source.clip = clip;
        source.Play();
    }

    public float GetVolume(AudioSourceType sourceType)
    {
        switch (sourceType)
        {
            case AudioSourceType.Master:
                return masterVolume;
            case AudioSourceType.Music:
                return musicVolume;
            case AudioSourceType.SFX:
                return sfxVolume;
            default:
                return 1.0f;
        }
    }

    public void SetVolume(AudioSourceType sourceType, float volume)
    {
        switch (sourceType)
        {
            case AudioSourceType.Master:
                masterVolume = volume;
                break;
            case AudioSourceType.Music:
                musicVolume = volume;
                break;
            case AudioSourceType.SFX:
                sfxVolume = volume;
                break;
        }

        musicSource.volume = masterVolume * musicVolume;
        sfxSource.volume = masterVolume * sfxVolume;
    }
}

public enum AudioSourceType
{
    Master,
    Music,
    SFX
}
