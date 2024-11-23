//using UnityEngine;
//using TMPro;

//public class UpgradeManager : MonoBehaviour
//{
//    public PlayerHealth playerHealth;
//    public Bullet bulletPrefab;

//    // Coin display for gameplay and shop
//    public TextMeshProUGUI gameCoinText; // For during the game
//    public TextMeshProUGUI shopCoinText; // For shop UI

//    // Upgrade UI buttons
//    public TextMeshProUGUI maxHealthButtonText;
//    public TextMeshProUGUI regenRateButtonText;
//    public TextMeshProUGUI medKitButtonText;
//    public TextMeshProUGUI damageButtonText;
//    public TextMeshProUGUI bulletDuplicationButtonText;

//    // Text to display current upgrade levels
//    public TextMeshProUGUI maxHealthLevelText;
//    public TextMeshProUGUI regenRateLevelText;
//    public TextMeshProUGUI medKitLevelText;
//    public TextMeshProUGUI damageLevelText;
//    public TextMeshProUGUI bulletDuplicationLevelText;

//    // Text to display player stats
//    public TextMeshProUGUI currentHealthText;
//    public TextMeshProUGUI currentRegenRateText;
//    public TextMeshProUGUI currentMedKitHealText;
//    public TextMeshProUGUI currentDamageText;
//    public TextMeshProUGUI currentBulletDuplicationText;

//    private int coins = 0;

//    private int maxHealthLevel = 1;
//    private int regenRateLevel = 1;
//    private int medKitLevel = 1;
//    private int damageLevel = 1;
//    private int bulletDuplicationLevel = 1;

//    private const int maxMedKitLevel = 5; // Maximum level for the med kit
//    private const string COINS_KEY = "PlayerCoins";

//    void Start()
//    {
//        // Load coins from persistent data
//        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
//        UpdateCoinsDisplay();
//        UpdateUpgradeButtons();
//        UpdatePlayerStats();
//    }

//    private void OnApplicationQuit()
//    {
//        SaveCoins();
//    }

//    private void SaveCoins()
//    {
//        PlayerPrefs.SetInt(COINS_KEY, coins);
//    }

//    public void CollectCoins(int amount)
//    {
//        coins += amount;
//        UpdateCoinsDisplay();
//    }

//    private void UpdateCoinsDisplay()
//    {
//        // Update both gameplay and shop coin displays
//        if (gameCoinText) gameCoinText.text = coins.ToString();
//        if (shopCoinText) shopCoinText.text = coins.ToString();
//    }

//    private void UpdateUpgradeButtons()
//    {
//        if (maxHealthButtonText)
//            maxHealthButtonText.text = (maxHealthLevel * 10).ToString();

//        if (regenRateButtonText)
//            regenRateButtonText.text = (regenRateLevel * 10).ToString();

//        if (medKitButtonText)
//        {
//            // Disable the button text if max level is reached
//            if (medKitLevel >= maxMedKitLevel)
//                medKitButtonText.text = "Max";
//            else
//                medKitButtonText.text = (medKitLevel * 5).ToString();
//        }

//        if (damageButtonText)
//            damageButtonText.text = (damageLevel * 10).ToString();

//        if (bulletDuplicationButtonText)
//            bulletDuplicationButtonText.text = (bulletDuplicationLevel * 25).ToString();

//        // Update level text display
//        if (maxHealthLevelText) maxHealthLevelText.text = maxHealthLevel.ToString();
//        if (regenRateLevelText) regenRateLevelText.text = regenRateLevel.ToString();
//        if (medKitLevelText) medKitLevelText.text = medKitLevel.ToString();
//        if (damageLevelText) damageLevelText.text = damageLevel.ToString();
//        if (bulletDuplicationLevelText) bulletDuplicationLevelText.text = bulletDuplicationLevel.ToString();
//    }

//    private void UpdatePlayerStats()
//    {
//        if (currentHealthText) currentHealthText.text = playerHealth.maxHealth.ToString();
//        if (currentRegenRateText) currentRegenRateText.text = playerHealth.regenRate.ToString("F1"); // Format to 1 decimal
//        if (currentMedKitHealText) currentMedKitHealText.text = playerHealth.medKitHealAmount.ToString();
//        if (currentDamageText) currentDamageText.text = bulletPrefab.damage.ToString();
//        if (currentBulletDuplicationText) currentBulletDuplicationText.text = bulletPrefab.bulletDuplicateCount.ToString();
//    }

//    private bool TryPurchaseUpgrade(int cost)
//    {
//        if (coins >= cost)
//        {
//            coins -= cost;
//            UpdateCoinsDisplay();
//            return true;
//        }
//        else
//        {
//            Debug.Log("Not enough coins for this upgrade.");
//            return false;
//        }
//    }

//    public void UpgradeMaxHealth()
//    {
//        int cost = maxHealthLevel * 10; // Cost scales with level
//        if (TryPurchaseUpgrade(cost))
//        {
//            maxHealthLevel++;
//            playerHealth.UpgradeMaxHealth(10);
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();
//        }
//    }

//    public void UpgradeRegenRate()
//    {
//        int cost = regenRateLevel * 10; // Cost scales with level
//        if (TryPurchaseUpgrade(cost))
//        {
//            regenRateLevel++;
//            playerHealth.UpgradeRegenRate(0.5f);
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();
//        }
//    }

//    public void UpgradeMedKitHealAmount()
//    {
//        if (medKitLevel >= maxMedKitLevel)
//        {
//            Debug.Log("Med Kit is already at maximum level!");
//            return;
//        }

//        int cost = medKitLevel * 5; // Cost scales with level
//        if (TryPurchaseUpgrade(cost))
//        {
//            medKitLevel++;
//            playerHealth.UpgradeMedKitHealAmount(5); // Applies upgrade to playerHealth
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();

//            // Update the MedKit prefab heal amount
//            UpdateMedKitHealAmount(playerHealth.medKitHealAmount);
//        }
//    }

//    private void UpdateMedKitHealAmount(int newHealAmount)
//    {
//        // Find all active MedKit objects and update their heal amount
//        MedKit[] medKits = FindObjectsOfType<MedKit>();
//        foreach (var medKit in medKits)
//        {
//            medKit.UpdateHealAmount(newHealAmount);
//        }
//    }

//    public void UpgradeDamage()
//    {
//        int cost = damageLevel * 10; // Cost scales with level
//        if (TryPurchaseUpgrade(cost))
//        {
//            damageLevel++;
//            bulletPrefab.UpgradeDamage(2);
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();
//        }
//    }

//    public void UpgradeBulletDuplication()
//    {
//        int cost = bulletDuplicationLevel * 15; // Cost scales with level
//        if (TryPurchaseUpgrade(cost))
//        {
//            bulletDuplicationLevel++;
//            bulletPrefab.UpgradeBulletDuplication(1);
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();
//        }
//    }
//}

using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Bullet bulletPrefab;

    // Coin display for gameplay and shop
    public TextMeshProUGUI gameCoinText; // For during the game
    public TextMeshProUGUI shopCoinText; // For shop UI

    // Upgrade UI buttons
    public TextMeshProUGUI maxHealthButtonText;
    public TextMeshProUGUI regenRateButtonText;
    public TextMeshProUGUI medKitButtonText;
    public TextMeshProUGUI damageButtonText;
    public TextMeshProUGUI bulletDuplicationButtonText;

    // Text to display current upgrade levels
    public TextMeshProUGUI maxHealthLevelText;
    public TextMeshProUGUI regenRateLevelText;
    public TextMeshProUGUI medKitLevelText;
    public TextMeshProUGUI damageLevelText;
    public TextMeshProUGUI bulletDuplicationLevelText;

    // Text to display player stats
    public TextMeshProUGUI currentHealthText; // To show the player's current max health
    public TextMeshProUGUI currentRegenRateText; // To show the player's regen rate
    public TextMeshProUGUI currentMedKitHealText; // To show the player's med kit healing amount
    public TextMeshProUGUI currentDamageText; // To show bullet damage
    public TextMeshProUGUI currentBulletDuplicationText; // To show the number of bullet duplications

    private int coins = 0;

    private int maxHealthLevel = 1;
    private int regenRateLevel = 1;
    private int medKitLevel = 1;
    private int damageLevel = 1;
    private int bulletDuplicationLevel = 1;

    private const int maxMedKitLevel = 5; // Maximum level for the med kit
    private const string COINS_KEY = "PlayerCoins";
    private const string MAX_HEALTH_KEY = "MaxHealthLevel";
    private const string REGEN_RATE_KEY = "RegenRateLevel";
    private const string MED_KIT_KEY = "MedKitLevel";
    private const string DAMAGE_KEY = "DamageLevel";
    private const string BULLET_DUPLICATION_KEY = "BulletDuplicationLevel";

    void Start()
    {
        // Load saved data
        LoadUpgradeData();
        UpdateUI();
    }

    private void SaveUpgradeData()
    {
        PlayerPrefs.SetInt(COINS_KEY, coins);
        PlayerPrefs.SetInt(MAX_HEALTH_KEY, maxHealthLevel);
        PlayerPrefs.SetInt(REGEN_RATE_KEY, regenRateLevel);
        PlayerPrefs.SetInt(MED_KIT_KEY, medKitLevel);
        PlayerPrefs.SetInt(DAMAGE_KEY, damageLevel);
        PlayerPrefs.SetInt(BULLET_DUPLICATION_KEY, bulletDuplicationLevel);
        PlayerPrefs.Save();
    }

    private void LoadUpgradeData()
    {
        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
        maxHealthLevel = PlayerPrefs.GetInt(MAX_HEALTH_KEY, 1);
        regenRateLevel = PlayerPrefs.GetInt(REGEN_RATE_KEY, 1);
        medKitLevel = PlayerPrefs.GetInt(MED_KIT_KEY, 1);
        damageLevel = PlayerPrefs.GetInt(DAMAGE_KEY, 1);
        bulletDuplicationLevel = PlayerPrefs.GetInt(BULLET_DUPLICATION_KEY, 1);

        // Apply upgrades to Player and Bullet
        playerHealth.UpgradeMaxHealth((maxHealthLevel - 1) * 10);
        playerHealth.UpgradeRegenRate((regenRateLevel - 1) * 0.5f);
        playerHealth.UpgradeMedKitHealAmount((medKitLevel - 1) * 5);
        bulletPrefab.UpgradeDamage((damageLevel - 1) * 2);
        bulletPrefab.UpgradeBulletDuplication((bulletDuplicationLevel - 1));
    }

    public void CollectCoins(int amount)
    {
        coins += amount;
        UpdateCoinDisplay();
        SaveUpgradeData();
    }

    private void UpdateCoinDisplay()
    {
        if (gameCoinText) gameCoinText.text = coins.ToString();
        if (shopCoinText) shopCoinText.text = coins.ToString();
    }

    public void UpgradeMaxHealth()
    {
        int cost = maxHealthLevel * 10; // Cost scales with level
        if (TryPurchase(cost))
        {
            maxHealthLevel++;
            playerHealth.UpgradeMaxHealth(10);
            UpdateUI();
            SaveUpgradeData();
        }
    }

    public void UpgradeRegenRate()
    {
        int cost = regenRateLevel * 10; // Cost scales with level
        if (TryPurchase(cost))
        {
            regenRateLevel++;
            playerHealth.UpgradeRegenRate(0.5f);
            UpdateUI();
            SaveUpgradeData();
        }
    }

    public void UpgradeMedKitHealAmount()
    {
        if (medKitLevel >= maxMedKitLevel)
        {
            Debug.Log("Med Kit is already at maximum level!");
            return;
        }

        int cost = medKitLevel * 5; // Cost scales with level
        if (TryPurchase(cost))
        {
            medKitLevel++;
            playerHealth.UpgradeMedKitHealAmount(5);
            UpdateUI();
            SaveUpgradeData();
        }
    }

    public void UpgradeDamage()
    {
        int cost = damageLevel * 10; // Cost scales with level
        if (TryPurchase(cost))
        {
            damageLevel++;
            bulletPrefab.UpgradeDamage(2);
            UpdateUI();
            SaveUpgradeData();
        }
    }

    public void UpgradeBulletDuplication()
    {
        int cost = bulletDuplicationLevel * 15; // Cost scales with level
        if (TryPurchase(cost))
        {
            bulletDuplicationLevel++;
            bulletPrefab.UpgradeBulletDuplication(1);
            UpdateUI();
            SaveUpgradeData();
        }
    }

    public void ResetUpgrades()
    {
        // Reset coins and upgrade levels to defaults
        coins = 0;
        maxHealthLevel = 1;
        regenRateLevel = 1;
        medKitLevel = 1;
        damageLevel = 1;
        bulletDuplicationLevel = 1;

        // Reset Player and Bullet stats
        playerHealth.ResetStats();
        bulletPrefab.ResetStats();

        // Save reset data
        SaveUpgradeData();

        // Update UI to reflect reset
        UpdateUI();

        Debug.Log("All upgrades and coins have been reset.");
    }

    private bool TryPurchase(int cost)
    {
        if (coins >= cost)
        {
            coins -= cost;
            UpdateCoinDisplay();
            return true;
        }
        Debug.Log("Not enough coins.");
        return false;
    }

    private void UpdateUI()
    {
        UpdateCoinDisplay();

        if (maxHealthButtonText) maxHealthButtonText.text = (maxHealthLevel * 10).ToString();
        if (regenRateButtonText) regenRateButtonText.text = (regenRateLevel * 10).ToString();
        if (medKitButtonText) medKitButtonText.text = medKitLevel >= maxMedKitLevel ? "Max" : (medKitLevel * 5).ToString();
        if (damageButtonText) damageButtonText.text = (damageLevel * 10).ToString();
        if (bulletDuplicationButtonText) bulletDuplicationButtonText.text = (bulletDuplicationLevel * 25).ToString();

        if (maxHealthLevelText) maxHealthLevelText.text = maxHealthLevel.ToString();
        if (regenRateLevelText) regenRateLevelText.text = regenRateLevel.ToString();
        if (medKitLevelText) medKitLevelText.text = medKitLevel.ToString();
        if (damageLevelText) damageLevelText.text = damageLevel.ToString();
        if (bulletDuplicationLevelText) bulletDuplicationLevelText.text = bulletDuplicationLevel.ToString();

        if (currentHealthText) currentHealthText.text = playerHealth.maxHealth.ToString();
        if (currentRegenRateText) currentRegenRateText.text = playerHealth.regenRate.ToString("F1");
        if (currentMedKitHealText) currentMedKitHealText.text = playerHealth.medKitHealAmount.ToString();
        if (currentDamageText) currentDamageText.text = bulletPrefab.damage.ToString();
        if (currentBulletDuplicationText) currentBulletDuplicationText.text = bulletPrefab.bulletDuplicateCount.ToString();
    }
}













//using UnityEngine;
//using TMPro;

//public class UpgradeManager : MonoBehaviour
//{
//    public PlayerHealth playerHealth;
//    public Bullet bulletPrefab;

//    // Coin display for gameplay and shop
//    public TextMeshProUGUI gameCoinText; // For during the game
//    public TextMeshProUGUI shopCoinText; // For shop UI

//    // Upgrade UI buttons
//    public TextMeshProUGUI maxHealthButtonText;
//    public TextMeshProUGUI regenRateButtonText;
//    public TextMeshProUGUI medKitButtonText;
//    public TextMeshProUGUI damageButtonText;
//    public TextMeshProUGUI bulletDuplicationButtonText;

//    // Text to display current upgrade levels
//    public TextMeshProUGUI maxHealthLevelText;
//    public TextMeshProUGUI regenRateLevelText;
//    public TextMeshProUGUI medKitLevelText;
//    public TextMeshProUGUI damageLevelText;
//    public TextMeshProUGUI bulletDuplicationLevelText;

//    // Text to display player stats
//    public TextMeshProUGUI currentHealthText;
//    public TextMeshProUGUI currentRegenRateText;
//    public TextMeshProUGUI currentMedKitHealText;
//    public TextMeshProUGUI currentDamageText;
//    public TextMeshProUGUI currentBulletDuplicationText;

//    private int coins = 0;

//    private int maxHealthLevel = 1;
//    private int regenRateLevel = 1;
//    private int medKitLevel = 1;
//    private int damageLevel = 1;
//    private int bulletDuplicationLevel = 1;

//    private const int maxMedKitLevel = 5; // Maximum level for the med kit
//    private const string COINS_KEY = "PlayerCoins";
//    private const string MAX_HEALTH_LEVEL_KEY = "MaxHealthLevel";
//    private const string REGEN_RATE_LEVEL_KEY = "RegenRateLevel";
//    private const string MED_KIT_LEVEL_KEY = "MedKitLevel";
//    private const string DAMAGE_LEVEL_KEY = "DamageLevel";
//    private const string BULLET_DUPLICATION_LEVEL_KEY = "BulletDuplicationLevel";

//    void Start()
//    {
//        // Load persistent data
//        LoadUpgrades();

//        UpdateCoinsDisplay();
//        UpdateUpgradeButtons();
//        UpdatePlayerStats();
//    }

//    private void OnApplicationQuit()
//    {
//        SaveUpgrades();
//    }

//    private void SaveUpgrades()
//    {
//        PlayerPrefs.SetInt(COINS_KEY, coins);
//        PlayerPrefs.SetInt(MAX_HEALTH_LEVEL_KEY, maxHealthLevel);
//        PlayerPrefs.SetInt(REGEN_RATE_LEVEL_KEY, regenRateLevel);
//        PlayerPrefs.SetInt(MED_KIT_LEVEL_KEY, medKitLevel);
//        PlayerPrefs.SetInt(DAMAGE_LEVEL_KEY, damageLevel);
//        PlayerPrefs.SetInt(BULLET_DUPLICATION_LEVEL_KEY, bulletDuplicationLevel);
//    }

//    private void LoadUpgrades()
//    {
//        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
//        maxHealthLevel = PlayerPrefs.GetInt(MAX_HEALTH_LEVEL_KEY, 1);
//        regenRateLevel = PlayerPrefs.GetInt(REGEN_RATE_LEVEL_KEY, 1);
//        medKitLevel = PlayerPrefs.GetInt(MED_KIT_LEVEL_KEY, 1);
//        damageLevel = PlayerPrefs.GetInt(DAMAGE_LEVEL_KEY, 1);
//        bulletDuplicationLevel = PlayerPrefs.GetInt(BULLET_DUPLICATION_LEVEL_KEY, 1);

//        // Apply upgrades to player stats
//        playerHealth.UpgradeMaxHealth(10 * (maxHealthLevel - 1));
//        playerHealth.UpgradeRegenRate(0.5f * (regenRateLevel - 1));
//        playerHealth.UpgradeMedKitHealAmount(5 * (medKitLevel - 1));
//        bulletPrefab.UpgradeDamage(2 * (damageLevel - 1));
//        bulletPrefab.UpgradeBulletDuplication(bulletDuplicationLevel - 1);
//    }

//    public void CollectCoins(int amount)
//    {
//        coins += amount;
//        UpdateCoinsDisplay();
//    }

//    private void UpdateCoinsDisplay()
//    {
//        if (gameCoinText) gameCoinText.text = coins.ToString();
//        if (shopCoinText) shopCoinText.text = coins.ToString();
//    }

//    private void UpdateUpgradeButtons()
//    {
//        if (maxHealthButtonText) maxHealthButtonText.text = (maxHealthLevel * 10).ToString();
//        if (regenRateButtonText) regenRateButtonText.text = (regenRateLevel * 10).ToString();

//        if (medKitButtonText)
//        {
//            if (medKitLevel >= maxMedKitLevel)
//                medKitButtonText.text = "Max";
//            else
//                medKitButtonText.text = (medKitLevel * 5).ToString();
//        }

//        if (damageButtonText) damageButtonText.text = (damageLevel * 10).ToString();
//        if (bulletDuplicationButtonText) bulletDuplicationButtonText.text = (bulletDuplicationLevel * 25).ToString();

//        if (maxHealthLevelText) maxHealthLevelText.text = maxHealthLevel.ToString();
//        if (regenRateLevelText) regenRateLevelText.text = regenRateLevel.ToString();
//        if (medKitLevelText) medKitLevelText.text = medKitLevel.ToString();
//        if (damageLevelText) damageLevelText.text = damageLevel.ToString();
//        if (bulletDuplicationLevelText) bulletDuplicationLevelText.text = bulletDuplicationLevel.ToString();
//    }

//    private void UpdatePlayerStats()
//    {
//        if (currentHealthText) currentHealthText.text = playerHealth.maxHealth.ToString();
//        if (currentRegenRateText) currentRegenRateText.text = playerHealth.regenRate.ToString("F1");
//        if (currentMedKitHealText) currentMedKitHealText.text = playerHealth.medKitHealAmount.ToString();
//        if (currentDamageText) currentDamageText.text = bulletPrefab.damage.ToString();
//        if (currentBulletDuplicationText) currentBulletDuplicationText.text = bulletPrefab.bulletDuplicateCount.ToString();
//    }

//    // Upgrade methods (example for MedKit Heal Amount shown above)
//}
