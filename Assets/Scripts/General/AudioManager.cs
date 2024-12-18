using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;

    [Header("Music")]
    [SerializeField] private AudioSource titleScreenSource;
    [SerializeField] private AudioSource menuSource;
    [SerializeField] private AudioSource inGameSource;
    private bool isPlayingTitleMusic = false;
    private bool isPlayingMenuMusic = false;
    private bool isPlayingInGameMusic = false;


    [Header("Player FX")]
    [SerializeField] private AudioSource jumpingSource;
    [SerializeField] private AudioClip[] jumpClips;
    [SerializeField] private AudioSource attackingSource;
    [SerializeField] private AudioSource damageSource;
    [SerializeField] private AudioSource deathSource;

    [Header("UI")]
    [SerializeField] private AudioSource buttonSource;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Music
    public void PlayTitleMusic()
    {
        if (!isPlayingTitleMusic)
        {
            titleScreenSource.Play();
            menuSource.Stop();
            inGameSource.Stop();
            isPlayingTitleMusic = true;
            isPlayingMenuMusic = false;
            isPlayingInGameMusic = false;
        }
    }
    public void PlayMenuMusic()
    {
        if (!isPlayingMenuMusic)
        {
            menuSource.Play();
            titleScreenSource.Stop();
            inGameSource.Stop();
            isPlayingTitleMusic = false;
            isPlayingMenuMusic = true;
            isPlayingInGameMusic = false;
        }
    }
    public void PlayInGameMusic()
    {
        if (!isPlayingInGameMusic)
        {
            inGameSource.Play();
            titleScreenSource.Stop();
            menuSource.Stop();
            isPlayingTitleMusic = false;
            isPlayingMenuMusic = false;
            isPlayingInGameMusic = true;
        }
    }

    public void StopMusic()
    {
        titleScreenSource.Stop();
        menuSource.Stop();
        inGameSource.Stop();
        isPlayingTitleMusic = false;
        isPlayingMenuMusic = false;
        isPlayingInGameMusic = false;
    }

    // Player FX
    public void PlayJumpSound()
    {
        jumpingSource.clip = jumpClips[Random.Range(0, jumpClips.Length)];
        jumpingSource.Play();
    }
    public void PlayAttackSound()
    {
        attackingSource.Play();
    }
    public void PlayDamageSound()
    {
        damageSource.Play();
    }
    public void PlayDeathSound()
    {
        deathSource.Play();
    }

    // UI FX
    public void PlayButtonSound()
    {
        buttonSource.Play();
        
    }
    

}
