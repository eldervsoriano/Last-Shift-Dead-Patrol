//using UnityEngine;

//public class UpgradeManager : MonoBehaviour
//{
//    public PlayerHealth playerHealth;
//    public Bullet bulletPrefab;
//    public PlayerMovement playerMovement;
//    private int coins = 0;

//    // Collect coins
//    public void CollectCoins(int amount) { coins += amount; }

//    // Methods to upgrade stats
//    public void UpgradeMaxHealth() { if (coins >= 10) { playerHealth.UpgradeMaxHealth(10); coins -= 10; } }
//    public void UpgradeRegenRate() { if (coins >= 10) { playerHealth.UpgradeRegenRate(0.5f); coins -= 10; } }
//    public void UpgradeMedKitHealAmount() { if (coins >= 5) { playerHealth.UpgradeMedKitHealAmount(5); coins -= 5; } }
//    public void UpgradeDamage() { if (coins >= 10) { bulletPrefab.UpgradeDamage(2); coins -= 10; } }
//    public void UpgradeBulletDuplication() { if (coins >= 15) { bulletPrefab.UpgradeBulletDuplication(1); coins -= 15; } }
//    public void UpgradeMovementSpeed() { if (coins >= 10) { playerMovement.UpgradeMovementSpeed(0.5f); coins -= 10; } }
//}

using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class UpgradeManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Bullet bulletPrefab;
    public TextMeshProUGUI coinsText;  // Reference to TextMeshProUGUI for displaying coins

    private int coins = 0;

    void Update()
    {
        // Update the UI every frame
        coinsText.text = "Coins: " + coins.ToString();
    }

    // Collect coins
    public void CollectCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins Collected: " + amount);
    }

    // Methods to upgrade stats
    public void UpgradeMaxHealth()
    {
        if (coins >= 10)
        {
            playerHealth.UpgradeMaxHealth(10);
            coins -= 10;
            Debug.Log("Max Health Upgraded!");
        }
        else
        {
            Debug.Log("Not enough coins for Max Health Upgrade.");
        }
    }

    public void UpgradeRegenRate()
    {
        if (coins >= 10)
        {
            playerHealth.UpgradeRegenRate(0.5f);
            coins -= 10;
            Debug.Log("Health Regeneration Rate Upgraded!");
        }
        else
        {
            Debug.Log("Not enough coins for Regen Rate Upgrade.");
        }
    }

    public void UpgradeMedKitHealAmount()
    {
        if (coins >= 5)
        {
            playerHealth.UpgradeMedKitHealAmount(5);
            coins -= 5;
            Debug.Log("MedKit Heal Amount Upgraded!");
        }
        else
        {
            Debug.Log("Not enough coins for MedKit Upgrade.");
        }
    }

    public void UpgradeDamage()
    {
        if (coins >= 10)
        {
            bulletPrefab.UpgradeDamage(2);
            coins -= 10;
            Debug.Log("Bullet Damage Upgraded!");
        }
        else
        {
            Debug.Log("Not enough coins for Damage Upgrade.");
        }
    }

    public void UpgradeBulletDuplication()
    {
        if (coins >= 15)
        {
            bulletPrefab.UpgradeBulletDuplication(1);
            coins -= 15;
            Debug.Log("Bullet Duplication Upgraded!");
        }
        else
        {
            Debug.Log("Not enough coins for Bullet Duplication Upgrade.");
        }
    }

    // Removed UpgradeMovementSpeed method since it's not being used anymore
}
