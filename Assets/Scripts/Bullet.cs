//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public float speed = 20f;       // Speed of the bullet
//    public int damage = 10;         // Amount of damage the bullet deals
//    public Rigidbody rb;            // Reference to the Rigidbody for movement
//    public float lifeTime = 2f;     // Time before the bullet is destroyed

//    void Start()
//    {
//        // Set the bullet's velocity to move forward
//        rb.velocity = transform.forward * speed;

//        // Destroy the bullet after the specified lifetime
//        Destroy(gameObject, lifeTime);
//    }

//    // This method is called when the bullet collides with something (non-trigger colliders)
//    private void OnCollisionEnter(Collision collision)
//    {
//        // Check if the object hit has an EnemyHealth script
//        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

//        // If the object has a health component, apply damage
//        if (enemy != null)
//        {
//            enemy.TakeDamage(damage);  // Apply damage to the enemy
//        }

//        // Destroy the bullet if it collides with an object tagged "Zombie", "Wall", or "Furniture"
//        if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Furniture"))
//        {
//            Destroy(gameObject);
//        }
//    }

//    // This method is called when the bullet hits a trigger collider
//    private void OnTriggerEnter(Collider other)
//    {
//        // Check if the object hit has an EnemyHealth script
//        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

//        // If the object has a health component, apply damage
//        if (enemy != null)
//        {
//            enemy.TakeDamage(damage);  // Apply damage to the enemy
//        }

//        // Destroy the bullet if it triggers an object tagged "Zombie", "Wall", or "Furniture"
//        if (other.CompareTag("Zombie") || other.CompareTag("Wall") || other.CompareTag("Furniture"))
//        {
//            Destroy(gameObject);
//        }
//    }
//}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;           // Bullet speed
    public int damage = 10;             // Bullet damage
    public Rigidbody rb;
    public float lifeTime = 2f;
    public int bulletDuplicateCount = 0; // Number of additional bullets to duplicate

    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);

        // Duplicate bullets based on the upgrade level
        DuplicateBullets();
    }

    // Method to create duplicate bullets
    private void DuplicateBullets()
    {
        for (int i = 0; i < bulletDuplicateCount; i++)
        {
            Vector3 spread = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
            GameObject duplicate = Instantiate(gameObject, transform.position + spread, transform.rotation);
            duplicate.GetComponent<Bullet>().damage = this.damage;
            duplicate.GetComponent<Bullet>().bulletDuplicateCount = 0; // Prevent duplicates from duplicating
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (other.CompareTag("Zombie") || other.CompareTag("Wall") || other.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
    }

    // Upgrade methods
    public void UpgradeDamage(int amount) { damage += amount; }
    public void UpgradeBulletDuplication(int count) { bulletDuplicateCount += count; }
}

