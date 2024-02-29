using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] BackgroundSounds;

    public static AudioManager instance;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else
        {
            DontDestroyOnLoad(gameObject);
            return;
        }


        foreach (Sound s in BackgroundSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    private void Start()
    {
        //  Play("dsdds");
    }

    public void Play(string name)
    {
        //Finding the list of sounds we inputed
        Sound s = Array.Find(BackgroundSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound: " + name + " not found");
            return;
        }
        if (!s.source.isPlaying ) { s.source.Play(); }
    }

    public void Stop(string name)
    {
        //Finding the list of sounds we inputed
        Sound s = Array.Find(BackgroundSounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null)
        {
            return;
        }
    }

    public void setVolume(float vol)
    {
        BackgroundSounds[0].source = gameObject.GetComponent<AudioSource>();
        BackgroundSounds[0].volume = vol;
        BackgroundSounds[1].source = gameObject.GetComponent<AudioSource>();
        BackgroundSounds[1].volume = vol;
        BackgroundSounds[2].source = gameObject.GetComponent<AudioSource>();
        BackgroundSounds[2].volume = vol;
        BackgroundSounds[3].source = gameObject.GetComponent<AudioSource>();
        BackgroundSounds[3].volume = vol;
        BackgroundSounds[4].source = gameObject.GetComponent<AudioSource>();
        BackgroundSounds[4].volume = vol;
        BackgroundSounds[5].source = gameObject.GetComponent<AudioSource>();
        BackgroundSounds[5].volume = vol;
    }


}
