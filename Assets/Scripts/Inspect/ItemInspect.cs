using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspect : MonoBehaviour
{
    //public

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInspect>() != null)
        {
            other.GetComponent<PlayerInspect>().canPlayerInspect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInspect>() != null)
        {
            other.GetComponent<PlayerInspect>().canPlayerInspect = false;
        }
    }*/


    public GameObject inspectionUI;
    public GameObject itemObject;
    public Item item; 

    private bool isInspecting = false;
    private bool canInteract = true;

    void Update()
    {
        if (canInteract && !isInspecting && Input.GetKeyDown(KeyCode.E))
        {
            StartInspection();
        }
        else if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInspectionUI();
        }
        else if (isInspecting && Input.GetKeyDown(KeyCode.E))
        {
            AddToInventory();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerInspect>() != null) 
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInspect>() != null)
        {
            canInteract = false;
            if (isInspecting)
            {
                CloseInspectionUI();
            }
        }
    }

    void StartInspection()
    {
        inspectionUI.SetActive(true);
        isInspecting = true;
    }

    void CloseInspectionUI()
    {
        inspectionUI.SetActive(false);
        isInspecting = false;
    }

    void AddToInventory()
    {
        Inventory playerInventory = FindObjectOfType<Inventory>(); 
        if (playerInventory != null)
        {
            bool wasPickedUp = playerInventory.AddItem(item);
            if (wasPickedUp)
            {
                CloseInspectionUI();
                Destroy(itemObject);
                Destroy(gameObject); 
            }
        }
    }
}
