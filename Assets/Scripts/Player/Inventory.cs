using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 10; 
    public List<Item> items = new List<Item>();
    //public GameObject inventoryUI;

    /*private void Start()
    {
        CloseInventory(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleInventory(); 
        }
    }*/

    public bool AddItem(Item item)
    {
        if (items.Count < space)
        {
            items.Add(item);
            return true; 
        }
        else
        {
            Debug.Log("Inventory full");
            return false; 
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

   /* public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf); 
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false); 
    }*/
}
