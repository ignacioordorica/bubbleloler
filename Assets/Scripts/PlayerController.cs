using UnityEngine;

public enum CircleType {
    Blue,
    Red,
    Yellow
}

public class PlayerController : MonoBehaviour {
    public CircleType bulletColor;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    void Start() {
        InvokeRepeating("FireBullet", 0f, 1f / fireRate);
    }

    void Update() {
    }

    void FireBullet() {
        // Find the closest enemy to the cannon
        GameObject closestEnemy = FindClosestEnemy();

        if (closestEnemy != null) {
            // There is an enemy within range, so fire a bullet at it        // Instantiate a new bullet at the cannon's position
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Set the bullet's color to the current bullet color
            bullet.GetComponent<BulletController>().color = bulletColor;

            // Calculate the direction from the cannon to the enemy
            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;

            // Set the bullet's velocity in the direction of the enemy
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

    GameObject FindClosestEnemy() {
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        // Find all of the enemy objects in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Iterate through the enemies and find the closest one
        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance) {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        return closestEnemy;
    }
}
