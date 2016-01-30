using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Win32.SafeHandles;

public class AudioManager : Singleton<AudioManager>
{
    static AudioSource[] audioSourceMusic;

    public int numberOfMusicSources = 2;
    int currentAudioSource = 0;

    public bool SoundsOn = true;

    private bool _musicOn = true;
    public bool MusicOn
    {
        get
        {
            return _musicOn;
        }
        set
        {
            _musicOn = value;

            if (MusicOn)
            {
                foreach (AudioSource a in audioSourceMusic)
                {
                    a.mute = false;
                }
            }
            else
            {
                PauseMusic();
                foreach (AudioSource a in audioSourceMusic)
                {
                    a.mute = true;
                }
            }
        }
    }

    public float fadeInOutSpeed = 0.1f;

    void Awake()
    {
        audioSourceMusic = new AudioSource[numberOfMusicSources];
        for (int i = 0; i < numberOfMusicSources; i++)
        {
            audioSourceMusic[i] = gameObject.AddComponent<AudioSource>();
            audioSourceMusic[i].loop = true;
        }
    }

    public void SwitchMuteMusic()
    {
        MusicOn = !MusicOn;
    }

    public void SwitchMuteSounds()
    {
        SoundsOn = !SoundsOn;
    }

    IEnumerator FadeOut(AudioSource audioSource)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= fadeInOutSpeed;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        audioSource.volume = 0;
        audioSource.Pause();
    }

    IEnumerator FadeIn(AudioSource audioSource)
    {
        while (audioSource.volume < 1)
        {
            audioSource.volume += fadeInOutSpeed;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        audioSource.volume = 1;
    }

    public void PlayMusic(AudioClip clip, bool loop = true, float pitch = 1, bool forcePlay = false)
    {
        if (audioSourceMusic[currentAudioSource].clip != clip && clip != null)
        {
            StopMusic();

            currentAudioSource = (this.currentAudioSource + 1) % audioSourceMusic.Length;
            if (forcePlay)
            {
                audioSourceMusic[currentAudioSource].Stop();
            }
                        
            audioSourceMusic[currentAudioSource].pitch = pitch;
            audioSourceMusic[currentAudioSource].loop = loop;
            audioSourceMusic[currentAudioSource].clip = clip;
            audioSourceMusic[currentAudioSource].Play();
            StopCoroutine("FadeIn");
            StartCoroutine("FadeIn", audioSourceMusic[currentAudioSource]);
        }
        else
        {
            if (clip != null)
                audioSourceMusic[currentAudioSource].pitch = pitch;

            if (audioSourceMusic[currentAudioSource].clip == clip)
            {
        //        Debug.Log(clip + " clip is already started");
                if (!audioSourceMusic[currentAudioSource].isPlaying)
                    UnpauseMusic();
            }
            if (clip == null)
                Debug.Log(clip + " clip is null");
        }
    }

    public void StopMusic()
    {
        StopCoroutine("FadeOut");
        StartCoroutine("FadeOut", audioSourceMusic[currentAudioSource]);
    }

    public void PauseMusic()
    {
        audioSourceMusic[currentAudioSource].Pause();
    }

    public void UnpauseMusic()
    {
        audioSourceMusic[currentAudioSource].Play();
    }

    public void PlaySoundAtPoint(AudioClip sound, Vector3 position, float volume = 1.0f)
    {
        if (SoundsOn)
        {
            AudioSource.PlayClipAtPoint(sound, position, volume);
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        if (SoundsOn)
        {
            GameObject tempGO = new GameObject("TempAudio");

            var aSource = tempGO.AddComponent<AudioSource>();
            aSource.clip = clip;
            aSource.spatialBlend = 0;
            aSource.volume = volume;
            aSource.Play();
            Destroy(tempGO, clip.length);
        }
    }

}
