using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public AudioClip toggleOnSoundClip; 
    public AudioClip toggleOffSoundClip; 

    private Light flashlight;
    private AudioSource audioSource;

    private void Awake()
    {
        JoystickMasterScript.instance.FlashlightSetup(this.gameObject); 
    }

    void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false; 
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OpenAndCloseFlashlight();
        }
    }

    public void OpenAndCloseFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
        if (flashlight.enabled && toggleOnSoundClip != null)
        {
            audioSource.PlayOneShot(toggleOnSoundClip);
        }
        else if (!flashlight.enabled && toggleOffSoundClip != null)
        {
            audioSource.PlayOneShot(toggleOffSoundClip);
        }
    }
}
