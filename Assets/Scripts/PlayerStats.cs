using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Hunger")]
    public float maxHunger = 100f;
    public float currentHunger;
    public float hungerDrainRate = 2f;

    [Header("Thirst")]
    public float maxThirst = 100f;
    public float currentThirst;
    public float thirstDrainRate = 3f;

    [Header("Damage when starving/dehydrated")]
    public float starvationDamage = 2f;
    public float dehydrationDamage = 3f;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
    }

    void Update()
    {
        if (isDead) return;

        DrainStats();
        CheckDeath();
    }

    void DrainStats()
    {
        currentHunger -= hungerDrainRate * Time.deltaTime;
        currentThirst -= thirstDrainRate * Time.deltaTime;

        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);

        if (currentHunger <= 0)
            currentHealth -= starvationDamage * Time.deltaTime;

        if (currentThirst <= 0)
            currentHealth -= dehydrationDamage * Time.deltaTime;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        isDead = true;

        // Tell the death screen to show up
        DeathScreen deathScreen = FindFirstObjectByType<DeathScreen>();
        if (deathScreen != null)
            deathScreen.Show();
    }

    // Called by the death screen when the player clicks Respawn
    public void Respawn(Vector3 spawnPoint)
    {
        isDead = false;
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
        transform.position = spawnPoint;
    }
}
