using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] footstepSoundClips;
    public float footstepDelay = 0.5f;
    public float footstepVolume = 0.5f;

    private AudioSource audioSource;
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

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSound()
    {
        if (canPlayFootstep && footstepSoundClips.Length > 0)
        {
            int randomIndex = GetUniqueRandomIndex();
            if (randomIndex != -1)
            {
                audioSource.volume = footstepVolume; 
                audioSource.PlayOneShot(footstepSoundClips[randomIndex]);
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

    /*private void Start()
    {
        if (footstepSoundClips.Length > 0)
        {
            audioSource.clip = footstepSoundClips[0];
        }
    }

    public void PlayFootstepSound()
    {
        if (canPlayFootstep && footstepSoundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSoundClips.Length);
            audioSource.volume = footstepVolume; 
            audioSource.PlayOneShot(footstepSoundClips[randomIndex]);
            canPlayFootstep = false;
            StartCoroutine(FootstepDelay());
        }
    }*/

    private IEnumerator FootstepDelay()
    {
        yield return new WaitForSeconds(footstepDelay);
        canPlayFootstep = true;
    }

}
