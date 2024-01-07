using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowNoteSpawn : MonoBehaviour
{
    public GameObject yellowPaperPrefab;
    public Transform attachPoint; 

    public void SpawnPaper()
    {
        Instantiate(yellowPaperPrefab, attachPoint.transform.position, attachPoint.transform.rotation); 
    }
}
