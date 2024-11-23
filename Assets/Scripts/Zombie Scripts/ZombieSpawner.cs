using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs;  // Array to hold different zombie prefabs
    public Transform[] spawnPoints;    // Array of spawn points
    public float initialSpawnRate = 5f;  // Time between spawns at the start of the game
    public float minimumSpawnRate = 1f;  // Minimum time between spawns (hard limit)
    public float spawnRateDecrease = 0.1f;  // How much to decrease the spawn rate over time
    public float spawnRateDecreaseInterval = 10f; // How often to decrease the spawn rate (in seconds)

    private float currentSpawnRate;    // Current time between spawns
    private float nextSpawnTime;       // Time when the next spawn will occur

    void Start()
    {
        currentSpawnRate = initialSpawnRate;  // Initialize spawn rate
        nextSpawnTime = Time.time + currentSpawnRate;  // Set first spawn time
        StartCoroutine(ProgressiveSpawnRate()); // Start spawn rate progression
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + currentSpawnRate;  // Schedule the next spawn
        }
    }

    // Spawns a random zombie at a random spawn point
    void SpawnZombie()
    {
        if (zombiePrefabs.Length == 0 || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Zombie Prefabs or Spawn Points not assigned!");
            return;
        }

        // Choose a random zombie prefab
        GameObject zombiePrefab = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the zombie at the spawn point
        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Coroutine to decrease the spawn rate progressively
    private System.Collections.IEnumerator ProgressiveSpawnRate()
    {
        while (currentSpawnRate > minimumSpawnRate)
        {
            yield return new WaitForSeconds(spawnRateDecreaseInterval);
            currentSpawnRate = Mathf.Max(currentSpawnRate - spawnRateDecrease, minimumSpawnRate);
            Debug.Log("Spawn rate decreased to: " + currentSpawnRate + " seconds.");
        }
    }
}
