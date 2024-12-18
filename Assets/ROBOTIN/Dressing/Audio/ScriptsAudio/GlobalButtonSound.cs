using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound; // Asigna el sonido en el Inspector.
    private AudioSource audioSource;

    private void Awake()
    {
        // Crea un AudioSource global.
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Encuentra todos los botones y añade el evento.
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlaySound());
        }
    }

    private void PlaySound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}

