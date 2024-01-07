using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float blinkInterval = 0.5f; 
    private Light blinkLight;

    private void Start()
    {
        blinkLight = GetComponent<Light>();
        if (blinkLight != null)
        {
            StartCoroutine(Blink());
        }
        else
        {
            Debug.LogWarning("No Light component found!");
        }
    }

    private System.Collections.IEnumerator Blink()
    {
        while (true)
        {
            blinkLight.enabled = !blinkLight.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
