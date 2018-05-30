using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Options options;
    public Player player;
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public const int numItemSlots = 4;


    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem(int slot)
    {
                items[slot] = null;
                itemImages[slot].sprite = null;
                itemImages[slot].enabled = false;
                return;
    }
    public void UseItem(int slot)
    {
        if(items[slot] != null)
        {
            player.UsingItem(items[slot]);
            RemoveItem(slot);
        }
       
    }
    public bool IsEmpty(int slot)
    {
        if(items[slot] != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}