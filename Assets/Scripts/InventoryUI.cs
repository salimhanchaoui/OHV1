using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;   // the panel that shows/hides
    public Transform slotContainer;     // parent object holding all slots
    public GameObject slotPrefab;       // a single slot UI prefab

    private InventorySystem inventory;
    private bool isOpen = false;

    void Start()
    {
        inventory = FindFirstObjectByType<InventorySystem>();
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        // Press I to toggle inventory
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);

            if (isOpen)
                RefreshUI();
        }
    }

    void RefreshUI()
    {
        // Clear existing slots
        foreach (Transform child in slotContainer)
            Destroy(child.gameObject);

        // Create a slot for each item in inventory
        foreach (ItemStack stack in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotContainer);

            // Set the item name and quantity text
            TextMeshProUGUI text = slot.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
                text.text = stack.item.itemName + " x" + stack.quantity;

            // Set icon if item has one
            Image icon = slot.GetComponentInChildren<Image>();
            if (icon != null && stack.item.icon != null)
                icon.sprite = stack.item.icon;
        }
    }
}
