using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    // Array of type Sound class
    public Sound[] sounds;

    public static AudioManager instance;


    // Called before initialization
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // To make the sound persist between scenes
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Error, sound "+ name +" isnt assigned i guess audio manager dekhle bhai jara, typo waghera ya kuch");
            return;
        }
        s.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
