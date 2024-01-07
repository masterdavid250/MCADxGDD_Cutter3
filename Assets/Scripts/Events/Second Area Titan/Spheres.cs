using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Inventory>() != null)
        {
            other.GetComponent<Inventory>().sphereNumber += 1;
            Destroy(gameObject); 
        }
    }
}
