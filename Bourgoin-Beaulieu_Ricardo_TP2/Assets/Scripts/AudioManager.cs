using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource explosionSource;
    public AudioSource boostSource;                 
    public AudioSource musicSource;             
    public static AudioManager instance = null;     
    public float lowPitchRange = .95f;                                   
    public float highPitchRange = 1.05f;             


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }



    public void PlayExplosionSound(AudioClip clip)
    {
        explosionSource.clip = clip;
        explosionSource.Play();
    }

    public void StopExplosioNSound(AudioClip clip)
    {
        explosionSource.clip = clip;
        explosionSource.Stop();
    }

    public void PlayBoostSound(AudioClip clip)
    {
        boostSource.clip = clip;
        boostSource.Play();
    }

    public void StopBoostSound(AudioClip clip)
    {
        boostSource.clip = clip;
        boostSource.Stop();
    }

    public void PlayBGM(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopBGM(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Stop();
    }

}

