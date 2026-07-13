using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Hunger")]
    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDrainRate = 2f;   // points lost per second

    [Header("Thirst")]
    public float maxThirst = 100f;
    public float currentThirst;
    public float thirstDrainRate = 3f;   // points lost per second

    [Header("Damage when starving/dehydrated")]
    public float starvationDamage = 2f;  // health lost per second when hunger = 0
    public float dehydrationDamage = 3f; // health lost per second when thirst = 0

    void Start()
    {
        // Start full
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
    }

    void Update()
    {
        DrainStats();
        CheckDeath();
    }

    void DrainStats()
    {
        // Hunger and thirst go down over time
        currentHunger -= hungerDrainRate * Time.deltaTime;
        currentThirst -= thirstDrainRate * Time.deltaTime;

        // Clamp so they never go below 0
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);

        // If starving, drain health
        if (currentHunger <= 0)
            currentHealth -= starvationDamage * Time.deltaTime;

        // If dehydrated, drain health faster
        if (currentThirst <= 0)
            currentHealth -= dehydrationDamage * Time.deltaTime;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // For now just log — we will add respawn later
        Debug.Log("Player died!");
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
    }
}
