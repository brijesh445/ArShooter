using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player; // Drag and drop the player GameObject here
    public GameObject enemyPrefab; // Assign the enemy prefab to this field
    public float spawnRadius = 10.0f; // Adjust the spawn radius as needed
    public float spawnInterval = 2.0f; // Adjust the spawn interval as needed
    public float enemySpeed = 2.0f; // Adjust the speed of enemies as needed

     

    void Start()
    {
        // Invoke the SpawnEnemy function repeatedly with the specified interval
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Calculate a random position around the player within the spawn radius
        Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 0; // Ensure enemies spawn at the same height as the player

        // Instantiate the enemy at the calculated position
        GameObject enemy = Instantiate(enemyPrefab, player.position + randomPosition, Quaternion.identity);

        // Move the enemy towards the player with the specified speed
        enemy.GetComponent<Rigidbody>().velocity = (player.position - enemy.transform.position).normalized * enemySpeed;
    }
}
