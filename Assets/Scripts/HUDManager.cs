using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [Header("Stat Bars")]
    public Slider healthBar;
    public Slider hungerBar;
    public Slider thirstBar;

    private PlayerStats playerStats;

    void Start()
    {
        // Find the PlayerStats script in the scene
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    void Update()
    {
        if (playerStats == null) return;

        // Update each bar to match the current stat values
        healthBar.value = playerStats.currentHealth / playerStats.maxHealth;
        hungerBar.value = playerStats.currentHunger / playerStats.maxHunger;
        thirstBar.value = playerStats.currentThirst / playerStats.maxThirst;
    }
}
