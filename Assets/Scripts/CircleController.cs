using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour {
    public CircleType type;
    public float speed = 1f;
    public int health = 10;
    public GameObject player;

    void Update() {
        switch (type) {
            case CircleType.Blue:
                // Move the blue circle towards the player character
                transform.Translate(0f, -speed * Time.deltaTime, 0f);
                break;
            case CircleType.Red:
                // Move the red circle in a circular pattern around the player character
                // ???????????
                transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
                break;
            case CircleType.Yellow:
                // Move the yellow circle in a straight line towards the player character
                Vector3 direction = (player.transform.position - transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime);
                break;
        }
    }

    public void TakeDamage(int damage) {
        // Decrease the circle's health by the specified amount
        health -= damage;

        if (health <= 0) {
            // The circle has been destroyed
            Destroy(gameObject);
        }
    }
}
