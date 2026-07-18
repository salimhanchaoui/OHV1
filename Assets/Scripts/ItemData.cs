using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName = "Item";
    public Sprite icon;
    public int maxStackSize = 10;

    [Header("Item Type")]
    public ItemType itemType = ItemType.Resource;

    [Header("Stat Restoration (only for Food/Water)")]
    public float healthRestore = 0f;
    public float hungerRestore = 0f;
    public float thirstRestore = 0f;
}

public enum ItemType
{
    Resource,   // wood, metal etc — just stored in inventory
    Food,       // restores hunger when picked up
    Water,      // restores thirst when picked up
    Weapon      // for later
}
