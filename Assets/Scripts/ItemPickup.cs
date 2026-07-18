using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventorySystem inventory = other.GetComponent<InventorySystem>();
            PlayerStats stats = other.GetComponent<PlayerStats>();

            if (inventory != null && inventory.AddItem(item))
            {
                // Apply stat restoration if the item has any
                if (stats != null)
                {
                    stats.currentHealth = Mathf.Clamp(stats.currentHealth + item.healthRestore, 0, stats.maxHealth);
                    stats.currentHunger = Mathf.Clamp(stats.currentHunger + item.hungerRestore, 0, stats.maxHunger);
                    stats.currentThirst = Mathf.Clamp(stats.currentThirst + item.thirstRestore, 0, stats.maxThirst);
                }

                Destroy(gameObject);
            }
        }
    }
}
