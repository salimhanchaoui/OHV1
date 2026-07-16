using UnityEngine;

// This is a ScriptableObject — a data container for items
// Right-click in Assets → Create → Item Data to make a new item
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName = "Item";
    public Sprite icon;             // optional icon for UI
    public int maxStackSize = 10;   // how many can stack in one slot
}
