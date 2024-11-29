//using UnityEngine;
//using UnityEngine.UI;               // Import UI for handling health bar
//using TMPro;                       // Import TextMeshPro namespace for handling text

//public class EnemyHealth : MonoBehaviour
//{
//    public int maxHealth = 100;          // Maximum health
//    public int currentHealth;            // Current health
//    public Image healthBarFill;          // Reference to the UI health bar's fill object (drag the Image from the Inspector)
//    public TextMeshProUGUI healthText;   // Reference to the TextMeshProUGUI for displaying health text

//    void Start()
//    {
//        currentHealth = maxHealth;       // Initialize health
//        UpdateHealthBar();               // Update the health bar and text at the start
//    }

//    // Method to apply damage to the enemy
//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;         // Reduce health
//        UpdateHealthBar();               // Update the health bar and text after taking damage

//        if (currentHealth <= 0)
//        {
//            Die();                       // Call die if health reaches 0
//        }
//    }

//    // Method to update the health bar and text
//    void UpdateHealthBar()
//    {
//        // Ensure we are not dividing by zero and that healthBarFill is assigned
//        if (healthBarFill != null)
//        {
//            healthBarFill.fillAmount = (float)currentHealth / maxHealth;  // Update the fill amount based on health
//        }

//        // Update the health text if it's assigned
//        if (healthText != null)
//        {
//            healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();  // Show health in "current/max" format
//        }
//    }

//    // Method for enemy death
//    void Die()
//    {
//        Debug.Log("Enemy died!");        // Placeholder for death logic
//        Destroy(gameObject);             // Destroy the enemy object
//    }
//}






//using UnityEngine;
//using UnityEngine.UI;                // Import UI for handling health bar
//using TMPro;                         // Import TextMeshPro namespace for handling text

//public class EnemyHealth : MonoBehaviour
//{
//    public int maxHealth = 100;           // Maximum health
//    public int currentHealth;             // Current health
//    public Image healthBarFill;           // Reference to the UI health bar's fill object (drag the Image from the Inspector)
//    public TextMeshProUGUI healthText;    // Reference to the TextMeshProUGUI for displaying health text

//    public GameObject coinPrefab;         // Reference to the coin prefab for dropping on death
//    public int coinDropAmount = 1;        // Number of coins to drop on death

//    void Start()
//    {
//        currentHealth = maxHealth;        // Initialize health
//        UpdateHealthBar();                // Update the health bar and text at the start
//    }

//    // Method to apply damage to the enemy
//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;          // Reduce health
//        UpdateHealthBar();                // Update the health bar and text after taking damage

//        if (currentHealth <= 0)
//        {
//            Die();                        // Call die if health reaches 0
//        }
//    }

//    // Method to update the health bar and text
//    void UpdateHealthBar()
//    {
//        if (healthBarFill != null)
//        {
//            healthBarFill.fillAmount = (float)currentHealth / maxHealth;  // Update the fill amount based on health
//        }

//        if (healthText != null)
//        {
//            healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();  // Show health in "current/max" format
//        }
//    }

//    // Method for enemy death
//    //void Die()
//    //{
//    //    Debug.Log("Enemy died!");         // Placeholder for death logic

//    //    // Drop coin(s) at the enemy's position
//    //    for (int i = 0; i < coinDropAmount; i++)
//    //    {
//    //        Instantiate(coinPrefab, transform.position, Quaternion.identity);
//    //    }

//    //    Destroy(gameObject);              // Destroy the enemy object
//    //}

//    void Die()
//    {
//        Debug.Log("Enemy died!");

//        // Update player score
//        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
//        if (playerScore != null)
//        {
//            playerScore.AddPoints(10); // Add 10 points (or any value you choose)
//        }

//        // Drop coins
//        for (int i = 0; i < coinDropAmount; i++)
//        {
//            Instantiate(coinPrefab, transform.position, Quaternion.identity);
//        }

//        Destroy(gameObject); // Destroy the enemy
//    }

//}


//using UnityEngine;
//using UnityEngine.UI;                // Import UI for handling health bar
//using TMPro;                         // Import TextMeshPro namespace for handling text

//public class EnemyHealth : MonoBehaviour
//{
//    public int maxHealth = 100;           // Maximum health
//    public int currentHealth;             // Current health
//    public Image healthBarFill;           // Reference to the UI health bar's fill object (drag the Image from the Inspector)
//    public TextMeshProUGUI healthText;    // Reference to the TextMeshProUGUI for displaying health text

//    public GameObject coinPrefab;         // Reference to the coin prefab for dropping on death
//    public int coinDropAmount = 1;        // Number of coins to drop on death
//    public int scoreValue = 10;           // Score awarded when this enemy dies (set per prefab)

//    void Start()
//    {
//        currentHealth = maxHealth;        // Initialize health
//        UpdateHealthBar();                // Update the health bar and text at the start
//    }

//    // Method to apply damage to the enemy
//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;          // Reduce health
//        UpdateHealthBar();                // Update the health bar and text after taking damage

//        if (currentHealth <= 0)
//        {
//            Die();                        // Call die if health reaches 0
//        }
//    }

//    // Method to update the health bar and text
//    void UpdateHealthBar()
//    {
//        if (healthBarFill != null)
//        {
//            healthBarFill.fillAmount = (float)currentHealth / maxHealth;  // Update the fill amount based on health
//        }

//        if (healthText != null)
//        {
//            healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();  // Show health in "current/max" format
//        }
//    }

//    // Method for enemy death
//    void Die()
//    {
//        Debug.Log("Enemy died!");

//        // Update player score
//        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
//        if (playerScore != null)
//        {
//            playerScore.AddPoints(scoreValue); // Use the scoreValue for this enemy
//        }

//        // Drop coins
//        for (int i = 0; i < coinDropAmount; i++)
//        {
//            Instantiate(coinPrefab, transform.position, Quaternion.identity);
//        }

//        Destroy(gameObject); // Destroy the enemy
//    }
//}



using UnityEngine;
using UnityEngine.UI;                // Import UI for handling health bar
using TMPro;                         // Import TextMeshPro namespace for handling text

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;           // Maximum health
    public int currentHealth;             // Current health
    public Image healthBarFill;           // Reference to the UI health bar's fill object (drag the Image from the Inspector)
    public TextMeshProUGUI healthText;    // Reference to the TextMeshProUGUI for displaying health text

    public GameObject coinPrefab;         // Reference to the coin prefab for dropping on death
    public GameObject medKitPrefab;       // Reference to the med kit prefab
    public int coinDropAmount = 1;        // Number of coins to drop on death
    public int scoreValue = 10;           // Score awarded when this enemy dies (set per prefab)

    [Range(0f, 1f)] public float medKitDropChance = 0.2f; // 20% chance to drop a med kit

    void Start()
    {
        currentHealth = maxHealth;        // Initialize health
        UpdateHealthBar();                // Update the health bar and text at the start
    }

    // Method to apply damage to the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;          // Reduce health
        UpdateHealthBar();                // Update the health bar and text after taking damage

        if (currentHealth <= 0)
        {
            Die();                        // Call die if health reaches 0
        }
    }

    // Method to update the health bar and text
    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;  // Update the fill amount based on health
        }

        if (healthText != null)
        {
            healthText.text = currentHealth.ToString() + " / " + maxHealth.ToString();  // Show health in "current/max" format
        }
    }

    // Method for enemy death
    void Die()
    {
        Debug.Log("Enemy died!");

        // Update player score
        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        if (playerScore != null)
        {
            playerScore.AddPoints(scoreValue); // Use the scoreValue for this enemy
        }

        // Drop coins
        //for (int i = 0; i < coinDropAmount; i++)
        //{
        //    Instantiate(coinPrefab, transform.position, Quaternion.identity);
        //}

        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }

        // Random chance to drop a med kit
        if (medKitPrefab != null && Random.value <= medKitDropChance)
        {
            Instantiate(medKitPrefab, transform.position, Quaternion.identity);
            Debug.Log("MedKit dropped!");
        }

        Destroy(gameObject); // Destroy the enemy
    }
}



