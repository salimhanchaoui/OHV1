using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public int maxSlots = 16;

    // Each slot holds an item and a quantity
    public List<ItemStack> items = new List<ItemStack>();

    public bool AddItem(ItemData item)
    {
        // Check if item already exists in inventory and can stack
        foreach (ItemStack stack in items)
        {
            if (stack.item == item && stack.quantity < item.maxStackSize)
            {
                stack.quantity++;
                Debug.Log("Picked up: " + item.itemName);
                return true;
            }
        }

        // Otherwise add a new slot
        if (items.Count < maxSlots)
        {
            items.Add(new ItemStack(item, 1));
            Debug.Log("Picked up: " + item.itemName);
            return true;
        }

        Debug.Log("Inventory full!");
        return false;
    }
}

// Holds an item and how many of it we have
[System.Serializable]
public class ItemStack
{
    public ItemData item;
    public int quantity;

    public ItemStack(ItemData item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
