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
    public TextMeshProUGUI currentHealthText;
    public TextMeshProUGUI currentRegenRateText;
    public TextMeshProUGUI currentMedKitHealText;
    public TextMeshProUGUI currentDamageText;
    public TextMeshProUGUI currentBulletDuplicationText;

    private int coins = 0;

    private int maxHealthLevel = 1;
    private int regenRateLevel = 1;
    private int medKitLevel = 1;
    private int damageLevel = 1;
    private int bulletDuplicationLevel = 1;

    private const string COINS_KEY = "PlayerCoins";

    void Start()
    {
        // Load coins from persistent data
        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
        UpdateCoinsDisplay();
        UpdateUpgradeButtons();
        UpdatePlayerStats();
    }

    private void OnApplicationQuit()
    {
        SaveCoins();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(COINS_KEY, coins);
    }

    public void CollectCoins(int amount)
    {
        coins += amount;
        UpdateCoinsDisplay();
    }

    private void UpdateCoinsDisplay()
    {
        // Update both gameplay and shop coin displays
        if (gameCoinText) gameCoinText.text = coins.ToString();
        if (shopCoinText) shopCoinText.text = coins.ToString();
    }

    private void UpdateUpgradeButtons()
    {
        if (maxHealthButtonText)
            maxHealthButtonText.text = (maxHealthLevel * 10).ToString();

        if (regenRateButtonText)
            regenRateButtonText.text = (regenRateLevel * 10).ToString();

        if (medKitButtonText)
            medKitButtonText.text = (medKitLevel * 5).ToString();

        if (damageButtonText)
            damageButtonText.text = (damageLevel * 10).ToString();

        if (bulletDuplicationButtonText)
            bulletDuplicationButtonText.text = (bulletDuplicationLevel * 15).ToString();

        // Update level text display
        if (maxHealthLevelText) maxHealthLevelText.text = maxHealthLevel.ToString();
        if (regenRateLevelText) regenRateLevelText.text = regenRateLevel.ToString();
        if (medKitLevelText) medKitLevelText.text = medKitLevel.ToString();
        if (damageLevelText) damageLevelText.text = damageLevel.ToString();
        if (bulletDuplicationLevelText) bulletDuplicationLevelText.text = bulletDuplicationLevel.ToString();
    }

    private void UpdatePlayerStats()
    {
        if (currentHealthText) currentHealthText.text = playerHealth.maxHealth.ToString();
        if (currentRegenRateText) currentRegenRateText.text = playerHealth.regenRate.ToString("F1"); // Format to 1 decimal
        if (currentMedKitHealText) currentMedKitHealText.text = playerHealth.medKitHealAmount.ToString();
        if (currentDamageText) currentDamageText.text = bulletPrefab.damage.ToString();
        if (currentBulletDuplicationText) currentBulletDuplicationText.text = bulletPrefab.bulletDuplicateCount.ToString();
    }

    private bool TryPurchaseUpgrade(int cost)
    {
        if (coins >= cost)
        {
            coins -= cost;
            UpdateCoinsDisplay();
            return true;
        }
        else
        {
            Debug.Log("Not enough coins for this upgrade.");
            return false;
        }
    }

    public void UpgradeMaxHealth()
    {
        int cost = maxHealthLevel * 10; // Cost scales with level
        if (TryPurchaseUpgrade(cost))
        {
            maxHealthLevel++;
            playerHealth.UpgradeMaxHealth(10);
            UpdateUpgradeButtons();
            UpdatePlayerStats();
        }
    }

    public void UpgradeRegenRate()
    {
        int cost = regenRateLevel * 10; // Cost scales with level
        if (TryPurchaseUpgrade(cost))
        {
            regenRateLevel++;
            playerHealth.UpgradeRegenRate(0.5f);
            UpdateUpgradeButtons();
            UpdatePlayerStats();
        }
    }

    public void UpgradeMedKitHealAmount()
    {
        int cost = medKitLevel * 5; // Cost scales with level
        if (TryPurchaseUpgrade(cost))
        {
            medKitLevel++;
            playerHealth.UpgradeMedKitHealAmount(5);
            UpdateUpgradeButtons();
            UpdatePlayerStats();
        }
    }

    public void UpgradeDamage()
    {
        int cost = damageLevel * 10; // Cost scales with level
        if (TryPurchaseUpgrade(cost))
        {
            damageLevel++;
            bulletPrefab.UpgradeDamage(2);
            UpdateUpgradeButtons();
            UpdatePlayerStats();
        }
    }

    public void UpgradeBulletDuplication()
    {
        int cost = bulletDuplicationLevel * 15; // Cost scales with level
        if (TryPurchaseUpgrade(cost))
        {
            bulletDuplicationLevel++;
            bulletPrefab.UpgradeBulletDuplication(1);
            UpdateUpgradeButtons();
            UpdatePlayerStats();
        }
    }
}

//using UnityEngine;
//using TMPro;

//public class UpgradeManager : MonoBehaviour
//{
//    public PlayerHealth playerHealth; // Reference to PlayerHealth script
//    public Bullet bulletPrefab; // Reference to Bullet prefab

//    // UI for coins
//    public TextMeshProUGUI gameCoinText; // Coin display during gameplay
//    public TextMeshProUGUI shopCoinText; // Coin display in shop

//    // UI for upgrades
//    public TextMeshProUGUI maxHealthButtonText;
//    public TextMeshProUGUI regenRateButtonText;
//    public TextMeshProUGUI medKitButtonText;
//    public TextMeshProUGUI damageButtonText;
//    public TextMeshProUGUI bulletDuplicationButtonText;

//    // UI for current levels
//    public TextMeshProUGUI maxHealthLevelText;
//    public TextMeshProUGUI regenRateLevelText;
//    public TextMeshProUGUI medKitLevelText;
//    public TextMeshProUGUI damageLevelText;
//    public TextMeshProUGUI bulletDuplicationLevelText;

//    // Player stats display
//    public TextMeshProUGUI currentHealthText;
//    public TextMeshProUGUI currentRegenRateText;
//    public TextMeshProUGUI currentMedKitHealText;
//    public TextMeshProUGUI currentDamageText;
//    public TextMeshProUGUI currentBulletDuplicationText;

//    private int coins = 0;

//    // Upgrade levels
//    private int maxHealthLevel = 1;
//    private int regenRateLevel = 1;
//    private int medKitLevel = 1;
//    private int damageLevel = 1;
//    private int bulletDuplicationLevel = 1;

//    private const string COINS_KEY = "PlayerCoins";

//    void Start()
//    {
//        // Load coins from persistent data
//        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
//        UpdateCoinDisplays();
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
//        UpdateCoinDisplays();
//    }

//    private void UpdateCoinDisplays()
//    {
//        // Update both game and shop coin displays
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
//            medKitButtonText.text = (medKitLevel * 5).ToString();

//        if (damageButtonText)
//            damageButtonText.text = (damageLevel * 10).ToString();

//        if (bulletDuplicationButtonText)
//            bulletDuplicationButtonText.text = (bulletDuplicationLevel * 15).ToString();

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

//    private bool TryPurchaseUpgrade(int cost)
//    {
//        if (coins >= cost)
//        {
//            coins -= cost;
//            UpdateCoinDisplays();
//            return true;
//        }
//        Debug.Log("Not enough coins for this upgrade.");
//        return false;
//    }

//    public void UpgradeMaxHealth()
//    {
//        int cost = maxHealthLevel * 10;
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
//        int cost = regenRateLevel * 10;
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
//        int cost = medKitLevel * 5;
//        if (TryPurchaseUpgrade(cost))
//        {
//            medKitLevel++;
//            playerHealth.UpgradeMedKitHealAmount(5);
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();
//        }
//    }

//    public void UpgradeDamage()
//    {
//        int cost = damageLevel * 10;
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
//        int cost = bulletDuplicationLevel * 15;
//        if (TryPurchaseUpgrade(cost))
//        {
//            bulletDuplicationLevel++;
//            bulletPrefab.UpgradeBulletDuplication(1);
//            UpdateUpgradeButtons();
//            UpdatePlayerStats();
//        }
//    }
//}
