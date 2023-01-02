using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public CircleType color;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSpriteColor();
        Destroy(gameObject, 5);
    }

    void UpdateSpriteColor() {
        // Set the sprite color based on the bullet color
        switch (color) {
            case CircleType.Blue:
                spriteRenderer.color = Color.blue;
                break;
            case CircleType.Red:
                spriteRenderer.color = Color.red;
                break;
            case CircleType.Yellow:
                spriteRenderer.color = Color.yellow;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        CircleController circle = collision.gameObject.GetComponent<CircleController>();
        Destroy(gameObject);

        if (circle != null && circle.type == color) {
            // The bullet's color matches the circle's color, so do damage to the circle
            circle.TakeDamage(100);
        }
    }
}
