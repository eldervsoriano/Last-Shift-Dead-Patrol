//using UnityEngine;

//public class Coin : MonoBehaviour
//{
//    public int coinValue = 1;  // Value of the coin

//    private void OnTriggerEnter(Collider other)  // Use OnTriggerEnter2D for 2D
//    {
//        // Check if the player collided with the coin
//        if (other.CompareTag("Player"))
//        {
//            // Access the UpgradeManager and add the coin value
//            UpgradeManager upgradeManager = other.GetComponent<UpgradeManager>();
//            if (upgradeManager != null)
//            {
//                upgradeManager.CollectCoins(coinValue);  // Add coin value to the player's total
//            }

//            Destroy(gameObject);  // Remove the coin after collection
//        }
//    }
//}

using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpgradeManager upgradeManager = FindObjectOfType<UpgradeManager>();
            if (upgradeManager != null)
            {
                upgradeManager.CollectCoins(coinValue);
            }

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0); // Rotate around Y-axis
    }

}
