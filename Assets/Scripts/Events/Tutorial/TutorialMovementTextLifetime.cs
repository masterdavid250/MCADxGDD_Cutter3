using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovementTextLifetime : MonoBehaviour
{
    public void DestroyAfterAMinute()
    {
        Destroy(gameObject, 60f);
    }
}
