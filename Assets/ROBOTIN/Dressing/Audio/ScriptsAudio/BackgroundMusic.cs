using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
        AudioManager.instance.StopMusic();
    }

    public void PlayMusic(AudioClip newMusic)
    {
        if (audioSource.clip != newMusic)
        {
            audioSource.clip = newMusic;
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
