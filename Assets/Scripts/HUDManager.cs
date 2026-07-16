using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [Header("Stat Bars")]
    public Slider healthBar;
    public Slider hungerBar;
    public Slider thirstBar;

    [Header("Health Bar Colors")]
    public Color healthFullColor = Color.green;
    public Color healthLowColor = Color.red;
    public float lowHealthThreshold = 0.4f;  // below 40% turns red

    private PlayerStats playerStats;
    private Image healthBarFill;

    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();

        // Get the fill image inside the health bar slider
        healthBarFill = healthBar.fillRect.GetComponent<Image>();
    }

    void Update()
    {
        if (playerStats == null) return;

        float healthPercent = playerStats.currentHealth / playerStats.maxHealth;
        float hungerPercent = playerStats.currentHunger / playerStats.maxHunger;
        float thirstPercent = playerStats.currentThirst / playerStats.maxThirst;

        healthBar.value = healthPercent;
        hungerBar.value = hungerPercent;
        thirstBar.value = thirstPercent;

        // Smoothly change health bar color from green to red as health drops
        healthBarFill.color = Color.Lerp(healthLowColor, healthFullColor, healthPercent);
    }
}
