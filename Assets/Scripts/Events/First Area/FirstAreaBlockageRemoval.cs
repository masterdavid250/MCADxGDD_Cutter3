using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAreaBlockageRemoval : MonoBehaviour
{
    public GameObject[] blockers; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSMovement>() != null)
        {
            DestroyBlockers();
        }
    }

    private void DestroyBlockers()
    {
        foreach (GameObject blocker in blockers)
        {
            if (blocker != null)
            {
                Destroy(blocker);
            }
        }
    }
}
