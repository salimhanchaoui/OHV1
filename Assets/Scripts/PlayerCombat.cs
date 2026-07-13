using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [Header("Melee Attack")]
    public float attackDamage = 25f;
    public float attackRange = 2f;      // radius around player to hit enemies
    public float attackCooldown = 0.5f; // seconds between attacks

    private float attackTimer;

    void Update()
    {
        attackTimer -= Time.deltaTime;

        // Left mouse button to attack
        if (Mouse.current.leftButton.wasPressedThisFrame && attackTimer <= 0f)
        {
            Attack();
            attackTimer = attackCooldown;
        }
    }

    void Attack()
    {
        // Find all colliders within attack range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider hit in hitColliders)
        {
            // Skip the player itself
            if (hit.gameObject == gameObject) continue;

            // If the hit object has EnemyHealth, deal damage
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
                Debug.Log("Hit " + hit.gameObject.name + " for " + attackDamage + " damage!");
            }
        }
    }

    // Visualize attack range in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
