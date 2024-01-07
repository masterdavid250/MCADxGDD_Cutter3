using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanPedestal : MonoBehaviour
{
    public GameObject pedestalAttachPoint;
    public GameObject spherePrefab;
    public GameObject yellowPaperPedestal; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FPSMovement>() != null)
        {
            if (other.GetComponent<Inventory>().sphereNumber > 0) 
            {
                Instantiate(spherePrefab, pedestalAttachPoint.transform.position, pedestalAttachPoint.transform.rotation);
                other.GetComponent<Inventory>().spherePlaced += 1;
                other.GetComponent<Inventory>().sphereNumber -= 1;
                if (other.GetComponent<Inventory>().spherePlaced == 2)
                {
                    yellowPaperPedestal.GetComponent<YellowNoteSpawn>().SpawnPaper(); 
                }
            }
        }
    }
}
