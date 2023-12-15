using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] footstepSoundClips;
    public float footstepDelay = 0.5f;
    public float footstepVolume = 0.5f;
    public AudioClip backgroundMusic;

    private AudioSource backgroundMusicSource;
    private AudioSource footstepAudioSource;
    private bool canPlayFootstep = true;
    private int previousFootstepIndex = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        footstepAudioSource = gameObject.AddComponent<AudioSource>();
        footstepAudioSource.volume = footstepVolume;

        backgroundMusicSource = GetComponent<AudioSource>();
        if (backgroundMusic != null)
        {
            PlayBackgroundMusic();
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }

    public void PlayFootstepSound()
    {
        if (canPlayFootstep && footstepSoundClips.Length > 0)
        {
            int randomIndex = GetUniqueRandomIndex();
            if (randomIndex != -1)
            {
                footstepAudioSource.PlayOneShot(footstepSoundClips[randomIndex]);
                canPlayFootstep = false;
                StartCoroutine(FootstepDelay());
            }
        }
    }

    private int GetUniqueRandomIndex()
    {
        if (footstepSoundClips.Length == 1)
            return 0;

        int randomIndex = Random.Range(0, footstepSoundClips.Length);
        while (randomIndex == previousFootstepIndex)
        {
            randomIndex = Random.Range(0, footstepSoundClips.Length);
        }

        previousFootstepIndex = randomIndex;
        return randomIndex;
    }

    private IEnumerator FootstepDelay()
    {
        yield return new WaitForSeconds(footstepDelay);
        canPlayFootstep = true;
    }
}
