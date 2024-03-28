using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTowardsPlayer : MonoBehaviour
{
  

 public GameObject projectilePrefab; // The prefab of the projectile to be shot
    public Transform player; // Reference to the player's transform
    public float shootingInterval = 2f; // Interval between shots
    private float timeSinceLastShot = 0f;

    void Update()
    {
        // Calculate the direction from the current object to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Rotate the object to face the player
        transform.rotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

        // Count time since last shot
        timeSinceLastShot += Time.deltaTime;

        // If enough time has passed, shoot
        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f; // Reset the timer
        }
    }

    void Shoot()
    {
        // Instantiate a new projectile at the current object's position and rotation
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Get the rigidbody of the projectile and shoot it towards the player
        Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();
        projectileRb.velocity = (player.position - transform.position).normalized * 10f; // Adjust 10f to desired speed
    }


}
