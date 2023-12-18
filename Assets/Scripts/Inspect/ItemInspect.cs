using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspect : MonoBehaviour
{
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
            JoystickMasterScript.instance.ItemInspectSetup(this.gameObject, canInteract, isInspecting);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerInspect>() != null)
        {
            JoystickMasterScript.instance.RemoveSetupItem(SetupItemType.Item);
            canInteract = false;
            if (isInspecting)
            {
                CloseInspectionUI();
            }
        }
    }

    public void StartInspection()
    {
        inspectionUI.SetActive(true);
        isInspecting = true;
        JoystickMasterScript.instance.ItemInspectSetup(this.gameObject, canInteract, isInspecting);
    }

    public void CloseInspectionUI()
    {
        inspectionUI.SetActive(false);
        isInspecting = false;
        JoystickMasterScript.instance.ItemInspectSetup(this.gameObject, canInteract, isInspecting);
    }

    public void AddToInventory()
    {
        Inventory playerInventory = FindObjectOfType<Inventory>(); 
        if (playerInventory != null)
        {
            bool wasPickedUp = playerInventory.AddItem(item);
            if (wasPickedUp)
            {
                CloseInspectionUI();
                JoystickMasterScript.instance.RemoveSetupItem(SetupItemType.Item);
                Destroy(itemObject);
                Destroy(gameObject); 
            }
        }
    }
}
