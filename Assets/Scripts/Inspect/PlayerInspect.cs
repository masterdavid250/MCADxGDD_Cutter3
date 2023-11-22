using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInspect : MonoBehaviour
{
    public bool canPlayerInspect = false;
    //public GameObject inspectedItem; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayerInspect)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }
}
