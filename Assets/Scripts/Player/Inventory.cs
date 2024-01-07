using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 10; 
    public List<Item> items = new List<Item>();
    public int sphereNumber = 0;
    public int spherePlaced = 0;

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

    public Item GetItemByID(int id)
    {
        foreach (Item item in items)
        {
            if (item.itemID == id)
            {
                return item;
            }
        }
        return null; 
    }
}

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




/* public void ToggleInventory()
 {
     inventoryUI.SetActive(!inventoryUI.activeSelf); 
 }

 public void CloseInventory()
 {
     inventoryUI.SetActive(false); 
 }*/