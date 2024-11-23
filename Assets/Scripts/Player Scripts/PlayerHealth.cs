//using UnityEngine;
//using UnityEngine.SceneManagement; // Include this for scene management

//public class PlayerHealth : MonoBehaviour
//{
//    public int maxHealth = 100;        // Maximum health of the player
//    private int currentHealth;         // Current health of the player

//    public HealthBar healthBar;        // Reference to the UI health bar

//    void Start()
//    {
//        currentHealth = maxHealth;     // Initialize the player's health to max at the start
//        healthBar.SetMaxHealth(maxHealth);  // Set the health bar to max
//    }

//     Call this method to deal damage to the player
//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;       // Reduce the player's health by the damage amount
//        if (currentHealth < 0)
//        {
//            currentHealth = 0;         // Prevent health from going below zero
//        }
//        healthBar.SetHealth(currentHealth, maxHealth);  // Update the health bar

//        Debug.Log("Player took " + damage + " damage, current health: " + currentHealth); // Log the damage and health

//        if (currentHealth <= 0)
//        {
//            Die();                     // If health is 0 or less, call the Die method
//        }
//    }

//     Call this method to heal the player (optional)
//    public void Heal(int healAmount)
//    {
//        currentHealth += healAmount;   // Increase the player's health by the heal amount
//        if (currentHealth > maxHealth)
//        {
//            currentHealth = maxHealth; // Make sure health doesn't exceed max health
//        }
//        healthBar.SetHealth(currentHealth, maxHealth);  // Update the health bar
//    }

//     Called when the player's health reaches zero
//    private void Die()
//    {
//        Debug.Log("Player Died!");     // Log the death event
//         Reload the current scene to reset the game
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
//    }
//}

//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections; // Add this line for IEnumerator


//public class PlayerHealth : MonoBehaviour
//{
//    public int maxHealth = 100;            // Base max health
//    public float regenRate = 1f;           // Base health regeneration rate per second
//    public int medKitHealAmount = 20;      // Base amount healed by a med kit
//    public HealthBar healthBar;

//    private int currentHealth;
//    private bool isRegenerating = true;    // Controls if regeneration is active

//    void Start()
//    {
//        currentHealth = maxHealth;
//        healthBar.SetMaxHealth(maxHealth);
//        StartCoroutine(RegenerateHealth());  // Start health regeneration
//    }

//    // Damage the player and check for death
//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//        currentHealth = Mathf.Max(currentHealth, 0);
//        healthBar.SetHealth(currentHealth, maxHealth);

//        Debug.Log("Player took " + damage + " damage, current health: " + currentHealth);

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    // Heal the player (used by med kits)
//    public void Heal()
//    {
//        currentHealth += medKitHealAmount;
//        currentHealth = Mathf.Min(currentHealth, maxHealth);
//        healthBar.SetHealth(currentHealth, maxHealth);
//        Debug.Log("Player healed by " + medKitHealAmount + ", current health: " + currentHealth);
//    }

//    // Regenerate health over time
//    private IEnumerator RegenerateHealth()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(1f);
//            if (isRegenerating && currentHealth < maxHealth)
//            {
//                currentHealth += (int)regenRate;
//                currentHealth = Mathf.Min(currentHealth, maxHealth);
//                healthBar.SetHealth(currentHealth, maxHealth);
//            }
//        }
//    }

//    // Upgrade methods
//    public void UpgradeMaxHealth(int amount) { maxHealth += amount; }
//    public void UpgradeRegenRate(float amount) { regenRate += amount; }
//    public void UpgradeMedKitHealAmount(int amount) { medKitHealAmount += amount; }

//    private void Die()
//    {
//        Debug.Log("Player Died!");
//        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }
//}




using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;            // Base max health
    public float regenRate = 1f;           // Base health regeneration rate per second
    public int medKitHealAmount = 20;      // Base amount healed by a med kit
    public HealthBar healthBar;            // Reference to the health bar UI
    public GameObject gameOverPanel;       // Reference to the Game Over Panel


    private int currentHealth;             // Current player health
    private bool isRegenerating = true;    // Controls if regeneration is active

    void Start()
    {
        currentHealth = maxHealth;         // Initialize health to max at the start
        healthBar.SetMaxHealth(maxHealth); // Initialize the health bar
        StartCoroutine(RegenerateHealth()); // Start passive health regeneration

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Damage the player and check for death
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;           // Decrease health by damage amount
        currentHealth = Mathf.Max(currentHealth, 0); // Clamp health to zero
        healthBar.SetHealth(currentHealth, maxHealth); // Update the health bar

        Debug.Log("Player took " + damage + " damage, current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();                         // Trigger death if health reaches zero
        }
    }

    // Heal the player (used by med kits or healing abilities)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;       // Increase health by the heal amount
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Clamp health to maxHealth
        healthBar.SetHealth(currentHealth, maxHealth); // Update the health bar
        Debug.Log("Player healed by " + healAmount + ", current health: " + currentHealth);
    }

    // Regenerate health over time
    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second between regenerations

            if (isRegenerating && currentHealth < maxHealth)
            {
                currentHealth += Mathf.CeilToInt(regenRate); // Increase health by regen rate
                currentHealth = Mathf.Min(currentHealth, maxHealth); // Clamp health to maxHealth
                healthBar.SetHealth(currentHealth, maxHealth); // Update the health bar
            }
        }
    }

    // Upgrade player health capacity
    public void UpgradeMaxHealth(int amount)
    {
        maxHealth += amount;              // Increase max health
        currentHealth += amount;          // Optionally increase current health proportionally
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Clamp current health
        healthBar.SetMaxHealth(maxHealth); // Update the health bar's max value
        healthBar.SetHealth(currentHealth, maxHealth); // Update the current health bar
        Debug.Log("Max health upgraded to " + maxHealth);
    }

    // Upgrade health regeneration rate
    public void UpgradeRegenRate(float amount)
    {
        regenRate += amount;              // Increase health regeneration rate
        Debug.Log("Regen rate upgraded to " + regenRate + " per second");
    }

    // Upgrade med kit healing amount
    public void UpgradeMedKitHealAmount(int amount)
    {
        medKitHealAmount += amount;       // Increase the healing amount from med kits
        Debug.Log("Med kit heal amount upgraded to " + medKitHealAmount);
    }

    // Handle player death
    //private void Die()
    //{
    //    Debug.Log("Player Died!");

    //    if (gameOverPanel != null)
    //    {
    //        gameOverPanel.SetActive(true);
    //        Time.timeScale = 0f; // Pause the game
    //    }
    //}

    // Handle player death


    private void Die()
    {
        Debug.Log("Player Died!");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }


        // Destroy the player after showing the game-over UI
        StartCoroutine(DestroyPlayer());
        Time.timeScale = 0f;
        Debug.Log("Game paused. Time.timeScale set to 0.");
    }

    // Coroutine to delay player destruction for UI visibility
    private IEnumerator DestroyPlayer()
    {
        yield return null; // Wait for one frame to ensure the UI is visible
        Destroy(gameObject); // Destroy the player
    }

    public void ResetStats()
    {
        maxHealth = 100;
        regenRate = 1f;
        medKitHealAmount = 20;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth, maxHealth);

        Debug.Log("Player stats reset to defaults.");
    }

}