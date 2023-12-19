using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Header("Options")]
    [Range(1,2)]
    [SerializeField] private float _min = 1;
    [Range(3,5)]
    [SerializeField] private float _max = 5;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _sfxFlickers;

    [Header("References")]
    [SerializeField] private List<Light> _lights;

    private void Start()
    {
        StartCoroutine(CO_FlickerAfterXSeconds(_min, _max));
    }

    private IEnumerator CO_FlickerAfterXSeconds(float min, float max)
    {
        float flickerTimer = Random.Range(min, max);

        yield return new WaitForSeconds(flickerTimer);

        foreach (Light light in _lights)
        {
            light.enabled = false;
        }

        int randomSound = Random.Range(0, _sfxFlickers.Count);
        _audioSource.PlayOneShot(_sfxFlickers[randomSound]);

        yield return new WaitForSeconds(0.5f);

        foreach (Light light in _lights)
        {
            light.enabled = true;
        }

        StartCoroutine(CO_FlickerAfterXSeconds(_min, _max));
    }
}
