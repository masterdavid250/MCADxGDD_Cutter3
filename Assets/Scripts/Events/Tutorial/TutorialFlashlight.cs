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
            other.GetComponentInChildren<Light>().enabled = false;
            GameObject newObject = Instantiate(objectToSpawn, other.transform.position, Quaternion.identity);
            newObject.transform.SetParent(other.transform);
            Destroy(gameObject);
        }
    }
}
