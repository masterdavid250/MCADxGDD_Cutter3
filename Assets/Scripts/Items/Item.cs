using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemID; 
    public string itemName;
    public Sprite itemIcon;

    public Item(int id, string name, Sprite icon)
    {
        itemID = id;
        itemName = name;
        itemIcon = icon;
    }
}
