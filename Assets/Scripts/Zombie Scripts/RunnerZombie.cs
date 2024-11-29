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



//using UnityEngine;
//using UnityEngine.AI;

//public class RunnerZombie : MonoBehaviour
//{
//    private Transform player;               // Reference to the player's Transform
//    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
//    public float enemyDetectionRange;       // Detection range for the zombie
//    public float enemyAttackRange;          // Attack range for the zombie
//    public Animator animator;               // Animator for zombie animations

//    public int zombieDamage = 10;           // Damage the zombie deals to the player
//    public float attackCooldown = 2f;       // Time between attacks
//    private float nextAttackTime = 0f;      // Timer for the next attack

//    private PlayerHealth playerHealth;      // Reference to player's health script

//    void Start()
//    {
//        navAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();

//        // Automatically find the player GameObject and its Transform
//        GameObject playerObject = GameObject.FindWithTag("Player");
//        if (playerObject != null)
//        {
//            player = playerObject.transform;             // Assign the player's Transform
//            playerHealth = playerObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
//        }
//        else
//        {
//            Debug.LogError("Player object not found! Ensure the player has the 'Player' tag.");
//        }
//    }

//    private void Update()
//    {
//        if (player == null) return; // Do nothing if player is not assigned

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
//            navAgent.isStopped = true;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        // Resume movement when no longer colliding with the player
//        if (collision.transform == player)
//        {
//            // You can uncomment the following line if you want to stop movement
//            navAgent.isStopped = false;
//        }
//    }
//}



//using UnityEngine;
//using UnityEngine.AI;

//public class RunnerZombie : MonoBehaviour
//{
//    private Transform player;               // Reference to the player's Transform
//    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
//    public float enemyDetectionRange;       // Detection range for the zombie
//    public float enemyAttackRange;          // Attack range for the zombie
//    public Animator animator;               // Animator for zombie animations

//    public int zombieDamage = 10;           // Damage the zombie deals to the player
//    public float attackCooldown = 2f;       // Time between attacks
//    private float nextAttackTime = 0f;      // Timer for the next attack

//    private PlayerHealth playerHealth;      // Reference to player's health script

//    private const int idle = 0;
//    private const int run = 1;
//    private const int attack = 2;
//    private const int damageTaken = 3;
//    private const int death = 4;

//    void Start()
//    {
//        navAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();

//        // Automatically find the player GameObject and its Transform
//        GameObject playerObject = GameObject.FindWithTag("Player");
//        if (playerObject != null)
//        {
//            player = playerObject.transform;             // Assign the player's Transform
//            playerHealth = playerObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
//        }
//        else
//        {
//            Debug.LogError("Player object not found! Ensure the player has the 'Player' tag.");
//        }
//    }

//    private void Update()
//    {
//        if (player == null) return; // Do nothing if player is not assigned

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
//            animator.SetInteger("RunnerZombieAnimations", run);
//        }
//        else
//        {
//            animator.SetInteger("RunnerZombieAnimations", idle); // Zombie idles if player is out of detection range
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

//            // Trigger attack animation
//            animator.SetInteger("RunnerZombieAnimations", attack);

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
//            // Trigger damage animation
//            animator.SetInteger("RunnerZombieAnimations", damageTaken);
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        // Resume movement when no longer colliding with the player
//        if (collision.transform == player)
//        {
//            // Reset to idle state after collision
//            animator.SetInteger("RunnerZombieAnimations", idle);
//        }
//    }
//}


//using UnityEngine;
//using UnityEngine.AI;

//public class RunnerZombie : MonoBehaviour
//{
//    private Transform player;               // Reference to the player's Transform
//    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
//    public float enemyDetectionRange;       // Detection range for the zombie
//    public float enemyAttackRange;          // Attack range for the zombie
//    public Animator animator;               // Animator for zombie animations

//    public int zombieDamage = 10;           // Damage the zombie deals to the player
//    public float attackCooldown = 2f;       // Time between attacks
//    private float nextAttackTime = 0f;      // Timer for the next attack

//    private PlayerHealth playerHealth;      // Reference to player's health script

//    void Start()
//    {
//        navAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();

//        // Automatically find the player GameObject and its Transform
//        GameObject playerObject = GameObject.FindWithTag("Player");
//        if (playerObject != null)
//        {
//            player = playerObject.transform;             // Assign the player's Transform
//            playerHealth = playerObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
//        }
//        else
//        {
//            Debug.LogError("Player object not found! Ensure the player has the 'Player' tag.");
//        }
//    }

//    private void Update()
//    {
//        if (player == null) return; // Do nothing if player is not assigned

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
//            navAgent.isStopped = true;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        // Resume movement when no longer colliding with the player
//        if (collision.transform == player)
//        {
//            // You can uncomment the following line if you want to stop movement
//            navAgent.isStopped = false;
//        }
//    }
//}




//using UnityEngine;
//using UnityEngine.AI;

//public class RunnerZombie : MonoBehaviour
//{
//    private Transform player;               // Reference to the player's Transform
//    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
//    public float enemyDetectionRange;       // Detection range for the zombie
//    public float enemyAttackRange;          // Attack range for the zombie
//    public Animator animator;               // Animator for zombie animations

//    public int zombieDamage = 10;           // Damage the zombie deals to the player
//    public float attackCooldown = 2f;       // Time between attacks
//    private float nextAttackTime = 0f;      // Timer for the next attack

//    private PlayerHealth playerHealth;      // Reference to player's health script

//    void Start()
//    {
//        navAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();

//        // Automatically find the player GameObject and its Transform
//        GameObject playerObject = GameObject.FindWithTag("Player");
//        if (playerObject != null)
//        {
//            player = playerObject.transform;             // Assign the player's Transform
//            playerHealth = playerObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
//        }
//        else
//        {
//            Debug.LogError("Player object not found! Ensure the player has the 'Player' tag.");
//        }
//    }

//    private void Update()
//    {
//        if (player == null) return; // Do nothing if player is not assigned

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
//            animator.SetInteger("RunnerZombieAnimations", 1); // Set to walk animation
//        }
//        else
//        {
//            animator.SetInteger("RunnerZombieAnimations", 0); // Set to idle animation
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

//            animator.SetInteger("RunnerZombieAnimations", 2); // Set to attack animation

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
//            animator.SetInteger("RunnerZombieAnimations", 1); // Set to walk animation
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check if the collision is with the player
//        if (collision.transform == player)
//        {
//            // Optional: Stop the zombie from moving if colliding with the player
//            // This can be left out if you want the player to push the zombie
//            navAgent.isStopped = true;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        // Resume movement when no longer colliding with the player
//        if (collision.transform == player)
//        {
//            // You can uncomment the following line if you want to stop movement
//            navAgent.isStopped = false;
//        }
//    }

//    private void RotateTowardsPlayer()
//    {
//        // Get the direction to the player (on the Y axis plane)
//        Vector3 direction = player.position - transform.position;
//        direction.y = 0; // Keep the rotation in the horizontal plane (X-Z plane)

//        // Create a rotation based on the direction to the player
//        Quaternion targetRotation = Quaternion.LookRotation(direction);

//        // Rotate the zombie smoothly towards the player
//        float rotationSpeed = 5f; // Adjust this value for smoother or faster rotation
//        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
//    }

//}


using UnityEngine;
using UnityEngine.AI;

public class RunnerZombie : MonoBehaviour
{
    private Transform player;               // Reference to the player's Transform
    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
    private Rigidbody rb;                   // Reference to the Rigidbody
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
        rb = GetComponent<Rigidbody>();
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

        // Ensure Rigidbody doesn't interfere with NavMeshAgent
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        if (player == null) return; // Do nothing if player is not assigned

        // Call the methods to follow and attack the player
        FollowPlayer();
        AttackPlayer();

        // Maintain proper rotation
        RotateTowardsPlayer();
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within detection range
        if (distanceToPlayer <= enemyDetectionRange)
        {
            // Set the destination to the player's position
            navAgent.SetDestination(player.position);
            animator.SetInteger("RunnerZombieAnimations", 1); // Set to walk animation
        }
        else
        {
            animator.SetInteger("RunnerZombieAnimations", 0); // Set to idle animation
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

            animator.SetInteger("RunnerZombieAnimations", 2); // Set to attack animation

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
            animator.SetInteger("RunnerZombieAnimations", 1); // Set to walk animation
        }
    }

    private void RotateTowardsPlayer()
    {
        // Get the direction to the player (on the Y axis plane)
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Keep the rotation in the horizontal plane (X-Z plane)

        // Create a rotation based on the direction to the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Rotate the zombie smoothly towards the player
        float rotationSpeed = 5f; // Adjust this value for smoother or faster rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void FixedUpdate()
    {
        // Ensure the zombie stays grounded
        if (!navAgent.isOnNavMesh)
        {
            // Reposition the zombie if it's off the NavMesh
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 1f, NavMesh.AllAreas))
            {
                navAgent.Warp(hit.position);
            }
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
            navAgent.isStopped = false;
        }
    }
}
















//using UnityEngine;
//using UnityEngine.AI;

//public class RunnerZombie : MonoBehaviour
//{
//    private Transform player;               // Reference to the player's Transform
//    private NavMeshAgent navAgent;          // Reference to the NavMeshAgent
//    public float enemyDetectionRange;       // Detection range for the zombie
//    public float enemyAttackRange;          // Attack range for the zombie
//    public Animator animator;               // Animator for zombie animations

//    public int zombieDamage = 10;           // Damage the zombie deals to the player
//    public float attackCooldown = 2f;       // Time between attacks
//    private float nextAttackTime = 0f;      // Timer for the next attack

//    private PlayerHealth playerHealth;      // Reference to player's health script

//    void Start()
//    {
//        navAgent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();

//        // Automatically find the player GameObject and its Transform
//        GameObject playerObject = GameObject.FindWithTag("Player");
//        if (playerObject != null)
//        {
//            player = playerObject.transform;             // Assign the player's Transform
//            playerHealth = playerObject.GetComponent<PlayerHealth>(); // Get the PlayerHealth component
//        }
//        else
//        {
//            Debug.LogError("Player object not found! Ensure the player has the 'Player' tag.");
//        }
//    }

//    private void Update()
//    {
//        if (player == null) return; // Do nothing if player is not assigned

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

//            // Set the animation to run
//            animator.SetInteger("RunnerZombieAnimations", 1); // 1 for Running animation
//        }
//        else
//        {
//            // Set the animation to idle when not moving
//            animator.SetInteger("RunnerZombieAnimations", 2); // 2 for Idle animation
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

//            // Set the animation to attack
//            animator.SetInteger("RunnerZombieAnimations", 0); // 0 for Attack animation

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
//            // Set the animation to run when moving towards the player
//            animator.SetInteger("RunnerZombieAnimations", 1); // 1 for Running animation
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check if the collision is with the player
//        if (collision.transform == player)
//        {
//            // Optional: Stop the zombie from moving if colliding with the player
//            // This can be left out if you want the player to push the zombie
//            navAgent.isStopped = true;

//            // Set the animation to attack when colliding with the player
//            animator.SetInteger("RunnerZombieAnimations", 0); // 0 for Attack animation
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        // Resume movement when no longer colliding with the player
//        if (collision.transform == player)
//        {
//            // You can uncomment the following line if you want to stop movement
//            navAgent.isStopped = false;
//            // Set the animation to idle when not moving
//            animator.SetInteger("RunnerZombieAnimations", 2); // 2 for Idle animation
//        }
//    }
//}

