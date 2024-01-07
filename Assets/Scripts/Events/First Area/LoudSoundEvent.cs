using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LoudSoundEvent : MonoBehaviour
{
    public AudioClip spawnSound; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (spawnSound != null)
        {
            audioSource.clip = spawnSound;
            audioSource.Play();
        }

        Destroy(gameObject, 5f); 
    }
}
