using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarryNightPedestals : MonoBehaviour
{
    public List<StarryNightPedestals> pedestalSequence; 
    public float lowerAmount = 0.2f; 
    public float resetDelay = 2.0f; 
    public bool isLastPedestal = false; 

    private bool isActivated = false;
    private bool isResetting = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isActivated && other.gameObject.GetComponent<FPSMovement>() != null)
        {
            isActivated = true;
            LowerPedestal();

            if (pedestalSequence.Count > 0 && pedestalSequence[0] == this)
            {
                pedestalSequence.RemoveAt(0);

                if (isLastPedestal && pedestalSequence.Count == 0)
                {
                    Debug.Log("Sequence completed!");
                    return;
                }
            }
            else
            {
                Debug.Log("Wrong sequence, resetting...");
                ResetPedestals();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.gameObject.GetComponent<FPSMovement>() != null)
        {
            isActivated = true;
            LowerPedestal();

            if (pedestalSequence.Count > 0 && pedestalSequence[0] == this)
            {
                pedestalSequence.RemoveAt(0);

                if (isLastPedestal && pedestalSequence.Count == 0)
                {
                    Debug.Log("Sequence completed!");
                    return;
                }
            }
            else
            {
                Debug.Log("Wrong sequence, resetting...");
                ResetPedestals();
            }
        }
    }

    public void LowerPedestal()
    {
        transform.position -= Vector3.up * lowerAmount;
    }

    private void ResetPedestals()
    {
        if (!isResetting)
        {
            isResetting = true;
            Invoke("ResetPedestalPositions", resetDelay);
        }
    }

    private void ResetPedestalPositions()
    {
        transform.position = originalPosition;
        isActivated = false;
        isResetting = false;

        foreach (StarryNightPedestals pedestal in pedestalSequence)
        {
            pedestal.ResetSequence();
        }
    }

    private void ResetSequence()
    {
        if (isActivated)
        {
            isActivated = false;
            transform.position = originalPosition;
        }
    }
}
