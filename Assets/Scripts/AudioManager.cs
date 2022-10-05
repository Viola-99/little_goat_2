using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //public static AudioManager instance;

    private void Awake()
    {
        /*if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);*/

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void StartMusic()
    {
        Play("themeMusic");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Cannot find sound: " + name);
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Cannot find sound: " + name);
            return;
        }
        s.source.Stop();
    }

    public IEnumerator StartFade(string curSound, string newSound, float duration, float targetVolume)
    {
        Sound oldS = Array.Find(sounds, sound => sound.name == curSound);
        Sound newS = Array.Find(sounds, sound => sound.name == newSound);

        float currentTime = 0;
        float start = oldS.source.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            oldS.source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        oldS.source.Stop();
        newS.source.Play();
        yield break;
    }

    public void SetVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Cannot find sound: " + name);
            return;
        }
        s.source.volume = volume;
    }
}