using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData item;   // drag an ItemData ScriptableObject here

    private void OnTriggerEnter(Collider other)
    {
        // Check if the thing that touched this is the player
        if (other.CompareTag("Player"))
        {
            InventorySystem inventory = other.GetComponent<InventorySystem>();

            if (inventory != null && inventory.AddItem(item))
            {
                Destroy(gameObject);    // remove item from world after pickup
            }
        }
    }
}
