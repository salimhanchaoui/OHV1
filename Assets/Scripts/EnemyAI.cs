using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Detection")]
    public float detectionRange = 8f;   // how far the enemy can see the player
    public float attackRange = 1.5f;    // how close to start attacking

    [Header("Movement")]
    public float moveSpeed = 3f;

    [Header("Combat")]
    public float attackDamage = 10f;
    public float attackCooldown = 1f;   // seconds between attacks

    private Transform player;
    private PlayerStats playerStats;
    private float attackTimer;

    // Enemy states
    private enum State { Idle, Chase, Attack }
    private State currentState = State.Idle;

    void Start()
    {
        // Find the player in the scene
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerStats = playerObject.GetComponent<PlayerStats>();
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Decide state based on distance
        if (distanceToPlayer <= attackRange)
            currentState = State.Attack;
        else if (distanceToPlayer <= detectionRange)
            currentState = State.Chase;
        else
            currentState = State.Idle;

        // Act on current state
        switch (currentState)
        {
            case State.Idle:
                // Just stand still for now
                break;

            case State.Chase:
                ChasePlayer();
                break;

            case State.Attack:
                AttackPlayer();
                break;
        }
    }

    void ChasePlayer()
    {
        // Move toward the player
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );

        // Face the player
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }

    void AttackPlayer()
    {
        // Face the player while attacking
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);

        // Attack on cooldown
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0f)
        {
            playerStats.currentHealth -= attackDamage;
            attackTimer = attackCooldown;
            Debug.Log("Enemy attacked player!");
        }
    }

    // Draw detection and attack ranges in the Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
