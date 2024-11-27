//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyZombie : MonoBehaviour
//{
//    public Transform player;                // Reference to the player
//    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
//    public float enemyDetectionRange;        // Detection range for the zombie
//    public float enemyAttackRange;           // Attack range for the zombie
//    public Animator animator;                // Animator for zombie animations

//    public int zombieDamage = 10;            // Damage the zombie deals to the player
//    public float attackCooldown = 2f;        // Time between attacks
//    private float nextAttackTime = 0f;      // Timer for the next attack

//    private PlayerHealth playerHealth;       // Reference to player's health script

//    void Start()
//    {
//        navAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();

//        // Ensure the player has the PlayerHealth component
//        playerHealth = player.GetComponent<PlayerHealth>();
//    }

//    private void Update()
//    {
//        // Call the methods to follow and attack the player
//        FollowPlayer();
//        AttackPlayer();
//    }

//    private void FollowPlayer()
//    {
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//        // Check if the player is within detection range
//        if (distanceToPlayer <= enemyDetectionRange)
//        {
//            // Set the destination to the player's position
//            navAgent.SetDestination(player.position);
//        }
//    }

//    private void AttackPlayer()
//    {
//        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

//        // Check if the player is within attack range and if the zombie can attack again
//        if (distanceToPlayer <= enemyAttackRange && Time.time >= nextAttackTime)
//        {
//            nextAttackTime = Time.time + attackCooldown; // Set next attack time

//            // Stop the zombie from moving when it is attacking the player
//            navAgent.isStopped = true;

//            // Check if playerHealth reference is valid
//            if (playerHealth != null)
//            {
//                playerHealth.TakeDamage(zombieDamage); // Apply damage to player
//            }
//        }
//        else if (distanceToPlayer > enemyAttackRange)
//        {
//            // Resume movement if player moves out of attack range
//            navAgent.isStopped = false;
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check if the collision is with the player
//        if (collision.transform == player)
//        {
//            // Optional: Stop the zombie from moving if colliding with the player
//            // This can be left out if you want the player to push the zombie
//            // navAgent.isStopped = true;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        // Resume movement when no longer colliding with the player
//        if (collision.transform == player)
//        {
//            // You can uncomment the following line if you want to stop movement
//            // navAgent.isStopped = false;
//        }
//    }
//}

using UnityEngine;
using UnityEngine.AI;

public class BiggieZombie : MonoBehaviour
{
    private Transform player;               // Reference to the player's Transform
    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
    public float enemyDetectionRange;       // Detection range for the zombie
    public float enemyAttackRange;          // Attack range for the zombie
    public Animator animator;               // Animator for zombie animations

    public int zombieDamage = 10;           // Damage the zombie deals to the player
    public float attackCooldown = 2f;       // Time between attacks
    private float nextAttackTime = 0f;      // Timer for the next attack

    private PlayerHealth playerHealth;      // Reference to player's health script

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Automatically find the player GameObject and its Transform
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;             // Assign the player's Transform
            playerHealth = playerObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
        }
        else
        {
            Debug.LogError("Player object not found! Ensure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player == null) return; // Do nothing if player is not assigned

        // Call the methods to follow and attack the player
        FollowPlayer();
        AttackPlayer();
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within detection range
        if (distanceToPlayer <= enemyDetectionRange)
        {
            // Set the destination to the player's position
            navAgent.SetDestination(player.position);
        }
    }

    private void AttackPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within attack range and if the zombie can attack again
        if (distanceToPlayer <= enemyAttackRange && Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCooldown; // Set next attack time

            // Stop the zombie from moving when it is attacking the player
            navAgent.isStopped = true;

            // Check if playerHealth reference is valid
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(zombieDamage); // Apply damage to player
            }
        }
        else if (distanceToPlayer > enemyAttackRange)
        {
            // Resume movement if player moves out of attack range
            navAgent.isStopped = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.transform == player)
        {
            // Optional: Stop the zombie from moving if colliding with the player
            // This can be left out if you want the player to push the zombie
            navAgent.isStopped = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Resume movement when no longer colliding with the player
        if (collision.transform == player)
        {
            // You can uncomment the following line if you want to stop movement
            navAgent.isStopped = false;
        }
    }
}

