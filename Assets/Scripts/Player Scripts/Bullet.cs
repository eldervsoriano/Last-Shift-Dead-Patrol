//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    public float speed = 20f;           // Bullet speed
//    public int damage = 10;             // Bullet damage
//    public Rigidbody rb;
//    public float lifeTime = 2f;
//    public int bulletDuplicateCount = 0; // Number of additional bullets to duplicate

//    void Start()
//    {
//        rb.velocity = transform.forward * speed;
//        Destroy(gameObject, lifeTime);

//        // Duplicate bullets based on the upgrade level
//        DuplicateBullets();
//    }

//    // Method to create duplicate bullets
//    private void DuplicateBullets()
//    {
//        for (int i = 0; i < bulletDuplicateCount; i++)
//        {
//            Vector3 spread = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
//            GameObject duplicate = Instantiate(gameObject, transform.position + spread, transform.rotation);
//            duplicate.GetComponent<Bullet>().damage = this.damage;
//            duplicate.GetComponent<Bullet>().bulletDuplicateCount = 0; // Prevent duplicates from duplicating
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
//        if (enemy != null)
//        {
//            enemy.TakeDamage(damage);
//        }

//        if (collision.gameObject.CompareTag("Zombie") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Furniture"))
//        {
//            Destroy(gameObject);
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
//        if (enemy != null)
//        {
//            enemy.TakeDamage(damage);
//        }

//        if (other.CompareTag("Zombie") || other.CompareTag("Wall") || other.CompareTag("Furniture"))
//        {
//            Destroy(gameObject);
//        }
//    }

//    // Upgrade methods
//    public void UpgradeDamage(int amount) { damage += amount; }
//    public void UpgradeBulletDuplication(int count) { bulletDuplicateCount += count; }
//}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;              // Bullet speed
    public int damage = 10;                // Bullet damage
    public Rigidbody rb;
    public float lifeTime = 2f;            // Lifetime of the bullet
    public int bulletDuplicateCount = 0;   // Number of additional bullets to spawn
    public float spreadAngle = 15f;        // Angle range for bullet duplication spread

    void Start()
    {
        // Move the bullet forward
        rb.velocity = transform.forward * speed;

        // Destroy the bullet after its lifetime expires
        Destroy(gameObject, lifeTime);

        // Create duplicate bullets
        DuplicateBullets();
    }

    // Method to create duplicate bullets with spread
    private void DuplicateBullets()
    {
        for (int i = 0; i < bulletDuplicateCount; i++)
        {
            // Calculate a random rotation within the spread angle
            Quaternion spreadRotation = Quaternion.Euler(
                Random.Range(-spreadAngle, spreadAngle),
                Random.Range(-spreadAngle, spreadAngle),
                0
            );

            // Instantiate a duplicate with the random rotation
            GameObject duplicate = Instantiate(
                gameObject,
                transform.position,
                transform.rotation * spreadRotation
            );

            // Configure the duplicate bullet
            Bullet duplicateBullet = duplicate.GetComponent<Bullet>();
            duplicateBullet.damage = this.damage;
            duplicateBullet.bulletDuplicateCount = 0; // Prevent infinite duplication
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    // Generalized collision handling
    private void HandleCollision(GameObject target)
    {
        // Apply damage if the target has an EnemyHealth component
        EnemyHealth enemy = target.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet on collision with specified tags
        if (target.CompareTag("Zombie") || target.CompareTag("Wall") || target.CompareTag("Furniture"))
        {
            Destroy(gameObject);
        }
    }

    // Upgrade methods
    public void UpgradeDamage(int amount)
    {
        damage += amount; // Increase bullet damage
    }

    public void UpgradeBulletDuplication(int count)
    {
        bulletDuplicateCount += count; // Increase the number of duplicate bullets
    }
}


