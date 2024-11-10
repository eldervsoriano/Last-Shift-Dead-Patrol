using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;  // Value of the coin

    private void OnTriggerEnter(Collider other)  // Use OnTriggerEnter2D for 2D
    {
        // Check if the player collided with the coin
        if (other.CompareTag("Player"))
        {
            // Access the UpgradeManager and add the coin value
            UpgradeManager upgradeManager = other.GetComponent<UpgradeManager>();
            if (upgradeManager != null)
            {
                upgradeManager.CollectCoins(coinValue);  // Add coin value to the player's total
            }

            Destroy(gameObject);  // Remove the coin after collection
        }
    }
}
