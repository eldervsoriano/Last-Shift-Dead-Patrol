//using UnityEngine;

//public class MedKit : MonoBehaviour
//{
//    public int healAmount = 20; // Default heal amount

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            // Heal the player
//            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
//            if (playerHealth != null)
//            {
//                playerHealth.Heal(healAmount);
//            }

//            // Destroy the med kit after use
//            Destroy(gameObject);
//        }
//    }

//    // Method to dynamically update the heal amount
//    public void UpdateHealAmount(int newHealAmount)
//    {
//        healAmount = newHealAmount;
//        Debug.Log("MedKit heal amount updated to: " + healAmount);
//    }

//    private void Update()
//    {
//        transform.Rotate(0, 100 * Time.deltaTime, 0); // Rotate around Y-axis
//    }
//}

using UnityEngine;

public class MedKit : MonoBehaviour
{
    public int healAmount = 20; // Default heal amount

    private void Start()
    {
        // Automatically destroy the med kit after 5 seconds
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Heal the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            // Destroy the med kit after use
            Destroy(gameObject);
        }
    }

    // Method to dynamically update the heal amount
    public void UpdateHealAmount(int newHealAmount)
    {
        healAmount = newHealAmount;
        Debug.Log("MedKit heal amount updated to: " + healAmount);
    }

    private void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0); // Rotate around Y-axis
    }
}
