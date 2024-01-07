using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarryNightFlashlightOff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<Flashlight>() != null)
        {
            other.gameObject.GetComponentInChildren<Flashlight>().OpenAndCloseFlashlight(); 
            other.gameObject.GetComponentInChildren<Flashlight>().canYouUseFlashlight = false; 
        }
    }
}
