//using UnityEngine;
//using TMPro;

//public class UpgradeManager : MonoBehaviour
//{
//    public PlayerHealth playerHealth;
//    public Bullet bulletPrefab;

//    // Coin display for gameplay and shop
//    public TextMeshProUGUI gameCoinText;
//    public TextMeshProUGUI shopCoinText;

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

//    // Maximum levels
//    private const int maxMaxHealthLevel = 10; // Added maximum level for health
//    private const int maxRegenRateLevel = 10;
//    private const int maxMedKitLevel = 5;
//    private const int maxBulletDuplicationLevel = 5;

//    private const string COINS_KEY = "PlayerCoins";
//    private const string MAX_HEALTH_KEY = "MaxHealthLevel";
//    private const string REGEN_RATE_KEY = "RegenRateLevel";
//    private const string MED_KIT_KEY = "MedKitLevel";
//    private const string DAMAGE_KEY = "DamageLevel";
//    private const string BULLET_DUPLICATION_KEY = "BulletDuplicationLevel";

//    void Start()
//    {
//        LoadUpgradeData();
//        UpdateUI();
//    }

//    //private void SaveUpgradeData()
//    //{
//    //    PlayerPrefs.SetInt(COINS_KEY, coins);
//    //    PlayerPrefs.SetInt(MAX_HEALTH_KEY, maxHealthLevel);
//    //    PlayerPrefs.SetInt(REGEN_RATE_KEY, regenRateLevel);
//    //    PlayerPrefs.SetInt(MED_KIT_KEY, medKitLevel);
//    //    PlayerPrefs.SetInt(DAMAGE_KEY, damageLevel);
//    //    PlayerPrefs.SetInt(BULLET_DUPLICATION_KEY, bulletDuplicationLevel);
//    //    PlayerPrefs.Save();
//    //}

//    private void SaveUpgradeData()
//    {
//        PlayerPrefs.SetInt(COINS_KEY, coins);
//        PlayerPrefs.SetInt(MAX_HEALTH_KEY, maxHealthLevel);
//        PlayerPrefs.SetInt(REGEN_RATE_KEY, regenRateLevel);
//        PlayerPrefs.SetInt(MED_KIT_KEY, medKitLevel);
//        PlayerPrefs.SetInt(DAMAGE_KEY, damageLevel);
//        PlayerPrefs.SetInt(BULLET_DUPLICATION_KEY, bulletDuplicationLevel); // Save the bullet duplication level
//        PlayerPrefs.Save();
//    }



//    //private void LoadUpgradeData()
//    //{
//    //    coins = PlayerPrefs.GetInt(COINS_KEY, 0);
//    //    maxHealthLevel = Mathf.Min(PlayerPrefs.GetInt(MAX_HEALTH_KEY, 1), maxMaxHealthLevel);
//    //    regenRateLevel = PlayerPrefs.GetInt(REGEN_RATE_KEY, 1);
//    //    medKitLevel = PlayerPrefs.GetInt(MED_KIT_KEY, 1);
//    //    damageLevel = PlayerPrefs.GetInt(DAMAGE_KEY, 1);
//    //    bulletDuplicationLevel = PlayerPrefs.GetInt(BULLET_DUPLICATION_KEY, 1);

//    //    playerHealth.UpgradeMaxHealth((maxHealthLevel - 1) * 10);
//    //    playerHealth.UpgradeRegenRate((regenRateLevel - 1) * 0.5f);
//    //    playerHealth.UpgradeMedKitHealAmount((medKitLevel - 1) * 5);
//    //    bulletPrefab.UpgradeDamage((damageLevel - 1) * 2);
//    //    bulletPrefab.UpgradeBulletDuplication((bulletDuplicationLevel - 1));
//    //}

//    //private void LoadUpgradeData()
//    //{
//    //    coins = PlayerPrefs.GetInt(COINS_KEY, 0);
//    //    maxHealthLevel = Mathf.Min(PlayerPrefs.GetInt(MAX_HEALTH_KEY, 1), maxMaxHealthLevel);
//    //    regenRateLevel = PlayerPrefs.GetInt(REGEN_RATE_KEY, 1);
//    //    medKitLevel = PlayerPrefs.GetInt(MED_KIT_KEY, 1);
//    //    damageLevel = PlayerPrefs.GetInt(DAMAGE_KEY, 1);

//    //    // Load bullet duplication level and cap it at maxBulletDuplicationLevel
//    //    bulletDuplicationLevel = Mathf.Min(PlayerPrefs.GetInt(BULLET_DUPLICATION_KEY, 1), maxBulletDuplicationLevel);

//    //    // Apply the loaded upgrade data to the player and bullet prefab
//    //    playerHealth.UpgradeMaxHealth((maxHealthLevel - 1) * 10);
//    //    playerHealth.UpgradeRegenRate((regenRateLevel - 1) * 0.5f);
//    //    playerHealth.UpgradeMedKitHealAmount((medKitLevel - 1) * 5);
//    //    bulletPrefab.UpgradeDamage((damageLevel - 1) * 2);
//    //    bulletPrefab.UpgradeBulletDuplication(bulletDuplicationLevel - 1); // Apply the correct level for duplication
//    //}

//    private void LoadUpgradeData()
//    {
//        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
//        maxHealthLevel = Mathf.Min(PlayerPrefs.GetInt(MAX_HEALTH_KEY, 1), maxMaxHealthLevel);
//        regenRateLevel = PlayerPrefs.GetInt(REGEN_RATE_KEY, 1);
//        medKitLevel = PlayerPrefs.GetInt(MED_KIT_KEY, 1);
//        damageLevel = PlayerPrefs.GetInt(DAMAGE_KEY, 1);

//        // Load bullet duplication level and cap it at maxBulletDuplicationLevel
//        bulletDuplicationLevel = Mathf.Min(PlayerPrefs.GetInt(BULLET_DUPLICATION_KEY, 1), maxBulletDuplicationLevel);

//        // Apply the loaded upgrade data to the player and bullet prefab
//        playerHealth.UpgradeMaxHealth((maxHealthLevel - 1) * 10);
//        playerHealth.UpgradeRegenRate((regenRateLevel - 1) * 0.5f);
//        playerHealth.UpgradeMedKitHealAmount((medKitLevel - 1) * 5);
//        bulletPrefab.UpgradeDamage((damageLevel - 1) * 2);

//        // Bullet duplication level should be set directly, not upgraded again.
//        bulletPrefab.SetBulletDuplicationLevel(bulletDuplicationLevel);
//    }



//    public void CollectCoins(int amount)
//    {
//        coins += amount;
//        UpdateCoinDisplay();
//        SaveUpgradeData();
//    }

//    private void UpdateCoinDisplay()
//    {
//        if (gameCoinText) gameCoinText.text = coins.ToString();
//        if (shopCoinText) shopCoinText.text = coins.ToString();
//    }

//    public void UpgradeMaxHealth()
//    {
//        if (maxHealthLevel >= maxMaxHealthLevel)
//        {
//            Debug.Log("Max Health is already at maximum level!");
//            return;
//        }

//        int cost = maxHealthLevel * 10;
//        if (TryPurchase(cost))
//        {
//            maxHealthLevel++;
//            playerHealth.UpgradeMaxHealth(10);
//            UpdateUI();
//            SaveUpgradeData();
//        }
//    }

//    public void UpgradeRegenRate()
//    {
//        if (regenRateLevel >= maxRegenRateLevel)
//        {
//            Debug.Log("Regen Rate is already at maximum level!");
//            return;
//        }

//        int cost = regenRateLevel * 10;
//        if (TryPurchase(cost))
//        {
//            regenRateLevel++;
//            playerHealth.UpgradeRegenRate(0.5f);
//            UpdateUI();
//            SaveUpgradeData();
//        }
//    }

//    public void UpgradeMedKitHealAmount()
//    {
//        if (medKitLevel >= maxMedKitLevel)
//        {
//            Debug.Log("Med Kit is already at maximum level!");
//            return;
//        }

//        int cost = medKitLevel * 5;
//        if (TryPurchase(cost))
//        {
//            medKitLevel++;
//            playerHealth.UpgradeMedKitHealAmount(5);
//            UpdateUI();
//            SaveUpgradeData();
//        }
//    }

//    public void UpgradeDamage()
//    {
//        int cost = damageLevel * 10;
//        if (TryPurchase(cost))
//        {
//            damageLevel++;
//            bulletPrefab.UpgradeDamage(2);
//            UpdateUI();
//            SaveUpgradeData();
//        }
//    }

//    //public void UpgradeBulletDuplication()
//    //{
//    //    if (bulletDuplicationLevel >= maxBulletDuplicationLevel)
//    //    {
//    //        Debug.Log("Bullet Duplication is already at maximum level!");
//    //        return;
//    //    }

//    //    int cost = bulletDuplicationLevel * 15;
//    //    if (TryPurchase(cost))
//    //    {
//    //        bulletDuplicationLevel++;
//    //        bulletPrefab.UpgradeBulletDuplication(1);
//    //        UpdateUI();
//    //        SaveUpgradeData();
//    //    }
//    //}

//    //public void UpgradeBulletDuplication()
//    //{
//    //    if (bulletDuplicationLevel >= maxBulletDuplicationLevel)
//    //    {
//    //        Debug.Log("Bullet Duplication is already at maximum level!");
//    //        return;
//    //    }

//    //    int cost = bulletDuplicationLevel * 15;
//    //    if (TryPurchase(cost))
//    //    {
//    //        bulletDuplicationLevel++;
//    //        bulletPrefab.UpgradeBulletDuplication(1); // Upgrade the duplication by 1
//    //        UpdateUI();
//    //        SaveUpgradeData();
//    //    }
//    //}

//    public void UpgradeBulletDuplication()
//    {
//        if (bulletDuplicationLevel >= maxBulletDuplicationLevel)
//        {
//            Debug.Log("Bullet Duplication is already at maximum level!");
//            return;
//        }

//        int cost = bulletDuplicationLevel * 15;
//        if (TryPurchase(cost))
//        {
//            bulletDuplicationLevel++;
//            bulletPrefab.UpgradeBulletDuplication(1); // Upgrade the duplication by 1
//            UpdateUI();
//            SaveUpgradeData();
//        }
//    }



//    public void ResetUpgrades()
//    {
//        coins = 0;
//        maxHealthLevel = 1;
//        regenRateLevel = 1;
//        medKitLevel = 1;
//        damageLevel = 1;
//        bulletDuplicationLevel = 1;

//        playerHealth.ResetStats();
//        bulletPrefab.ResetStats();

//        SaveUpgradeData();
//        UpdateUI();

//        Debug.Log("All upgrades and coins have been reset.");
//    }

//    private bool TryPurchase(int cost)
//    {
//        if (coins >= cost)
//        {
//            coins -= cost;
//            UpdateCoinDisplay();
//            return true;
//        }
//        Debug.Log("Not enough coins.");
//        return false;
//    }

//    private void UpdateUI()
//    {
//        UpdateCoinDisplay();

//        if (maxHealthButtonText)
//            maxHealthButtonText.text = maxHealthLevel >= maxMaxHealthLevel ? "Max" : (maxHealthLevel * 25).ToString();
//        if (regenRateButtonText)
//            regenRateButtonText.text = regenRateLevel >= maxRegenRateLevel ? "Max" : (regenRateLevel * 20).ToString();
//        if (medKitButtonText)
//            medKitButtonText.text = medKitLevel >= maxMedKitLevel ? "Max" : (medKitLevel * 25).ToString();
//        if (damageButtonText)
//            damageButtonText.text = (damageLevel * 15).ToString();
//        if (bulletDuplicationButtonText)
//            bulletDuplicationButtonText.text = bulletDuplicationLevel >= maxBulletDuplicationLevel ? "Max" : (bulletDuplicationLevel * 50).ToString();

//        if (maxHealthLevelText) maxHealthLevelText.text = maxHealthLevel.ToString();
//        if (regenRateLevelText) regenRateLevelText.text = regenRateLevel.ToString();
//        if (medKitLevelText) medKitLevelText.text = medKitLevel.ToString();
//        if (damageLevelText) damageLevelText.text = damageLevel.ToString();
//        if (bulletDuplicationLevelText) bulletDuplicationLevelText.text = bulletDuplicationLevel.ToString();

//        if (currentHealthText) currentHealthText.text = playerHealth.maxHealth.ToString();
//        if (currentRegenRateText) currentRegenRateText.text = playerHealth.regenRate.ToString("F1");
//        if (currentMedKitHealText) currentMedKitHealText.text = playerHealth.medKitHealAmount.ToString();
//        if (currentDamageText) currentDamageText.text = bulletPrefab.damage.ToString();
//        if (currentBulletDuplicationText) currentBulletDuplicationText.text = bulletPrefab.bulletDuplicateCount.ToString();
//    }
//}



using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Bullet bulletPrefab;

    // Coin display for gameplay and shop
    public TextMeshProUGUI gameCoinText;
    public TextMeshProUGUI shopCoinText;

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

    // Maximum levels
    private const int maxMaxHealthLevel = 10; // Added maximum level for health
    private const int maxRegenRateLevel = 10;
    private const int maxMedKitLevel = 5;
    private const int maxBulletDuplicationLevel = 5;

    private const string COINS_KEY = "PlayerCoins";
    private const string MAX_HEALTH_KEY = "MaxHealthLevel";
    private const string REGEN_RATE_KEY = "RegenRateLevel";
    private const string MED_KIT_KEY = "MedKitLevel";
    private const string DAMAGE_KEY = "DamageLevel";
    private const string BULLET_DUPLICATION_KEY = "BulletDuplicationLevel";

    void Start()
    {
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
        PlayerPrefs.SetInt(BULLET_DUPLICATION_KEY, bulletDuplicationLevel); // Save the bullet duplication level
        PlayerPrefs.Save();
    }



    private void LoadUpgradeData()
    {
        coins = PlayerPrefs.GetInt(COINS_KEY, 0);
        maxHealthLevel = Mathf.Min(PlayerPrefs.GetInt(MAX_HEALTH_KEY, 1), maxMaxHealthLevel);
        regenRateLevel = PlayerPrefs.GetInt(REGEN_RATE_KEY, 1);
        medKitLevel = PlayerPrefs.GetInt(MED_KIT_KEY, 1);
        damageLevel = PlayerPrefs.GetInt(DAMAGE_KEY, 1);

        // Load bullet duplication level and cap it at maxBulletDuplicationLevel
        bulletDuplicationLevel = Mathf.Min(PlayerPrefs.GetInt(BULLET_DUPLICATION_KEY, 1), maxBulletDuplicationLevel);

        // Apply the loaded upgrade data to the player and bullet prefab
        playerHealth.UpgradeMaxHealth((maxHealthLevel - 1) * 10);
        playerHealth.UpgradeRegenRate((regenRateLevel - 1) * 0.5f);
        playerHealth.UpgradeMedKitHealAmount((medKitLevel - 1) * 5);
        bulletPrefab.UpgradeDamage((damageLevel - 1) * 2);

        // Bullet duplication level should be set directly, not upgraded again.
        bulletPrefab.SetBulletDuplicationLevel(bulletDuplicationLevel);
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
        if (maxHealthLevel >= maxMaxHealthLevel)
        {
            Debug.Log("Max Health is already at maximum level!");
            return;
        }

        int cost = maxHealthLevel * 10;
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
        if (regenRateLevel >= maxRegenRateLevel)
        {
            Debug.Log("Regen Rate is already at maximum level!");
            return;
        }

        int cost = regenRateLevel * 10;
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

        int cost = medKitLevel * 5;
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
        int cost = damageLevel * 10;
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
        if (bulletDuplicationLevel >= maxBulletDuplicationLevel)
        {
            Debug.Log("Bullet Duplication is already at maximum level!");
            return;
        }

        int cost = bulletDuplicationLevel * 15;
        if (TryPurchase(cost))
        {
            bulletDuplicationLevel++;
            bulletPrefab.UpgradeBulletDuplication(1); // Upgrade the duplication by 1
            UpdateUI();
            SaveUpgradeData();
        }
    }



    public void ResetUpgrades()
    {
        coins = 0;
        maxHealthLevel = 1;
        regenRateLevel = 1;
        medKitLevel = 1;
        damageLevel = 1;
        bulletDuplicationLevel = 1;

        playerHealth.ResetStats();
        bulletPrefab.ResetStats();

        SaveUpgradeData();
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

        if (maxHealthButtonText)
            maxHealthButtonText.text = maxHealthLevel >= maxMaxHealthLevel ? "Max" : (maxHealthLevel * 25).ToString();
        if (regenRateButtonText)
            regenRateButtonText.text = regenRateLevel >= maxRegenRateLevel ? "Max" : (regenRateLevel * 20).ToString();
        if (medKitButtonText)
            medKitButtonText.text = medKitLevel >= maxMedKitLevel ? "Max" : (medKitLevel * 25).ToString();
        if (damageButtonText)
            damageButtonText.text = (damageLevel * 15).ToString();
        if (bulletDuplicationButtonText)
            bulletDuplicationButtonText.text = bulletDuplicationLevel >= maxBulletDuplicationLevel ? "Max" : (bulletDuplicationLevel * 50).ToString();

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


