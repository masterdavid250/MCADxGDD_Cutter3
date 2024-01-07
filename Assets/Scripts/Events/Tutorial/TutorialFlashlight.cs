using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFlashlight : MonoBehaviour
{
    public GameObject objectToSpawn; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FPSMovement>() != null)
        {
            //other.GetComponentInChildren<Flashlight>().flashlight.enabled = false;
            other.GetComponentInChildren<Flashlight>().OpenAndCloseFlashlight(); 
            GameObject newObject = Instantiate(objectToSpawn, other.transform.position, Quaternion.identity);
            newObject.transform.SetParent(other.transform);
            Destroy(gameObject);
        }
    }
}
