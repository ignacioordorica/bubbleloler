using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleSpawner : MonoBehaviour {
    public GameObject blueCirclePrefab;
    public GameObject redCirclePrefab;
    public GameObject yellowCirclePrefab;
    public float spawnInterval = 1f;
    void Start() {
        InvokeRepeating("SpawnCircle", spawnInterval, spawnInterval);
    }

    void SpawnCircle() {
        // Randomly select a type of circle to spawn
        int circleType = Random.Range(0, 3);

        switch (circleType) {
            case 0:
                SpawnBlueCircle();
                break;
            case 1:
                SpawnRedCircle();
                break;
            case 2:
                SpawnYellowCircle();
                break;
        }
    }
    void SpawnBlueCircle() {
        // Instantiate a blue circle at the spawn point's position
        GameObject blueCircle = Instantiate(blueCirclePrefab, transform.position, Quaternion.identity);
        blueCircle.GetComponent<CircleController>().type = CircleType.Blue;
    }

    void SpawnRedCircle() {
        // Instantiate a red circle at the spawn point's position
        GameObject redCircle = Instantiate(redCirclePrefab, transform.position, Quaternion.identity);
        redCircle.GetComponent<CircleController>().type = CircleType.Red;
    }

    void SpawnYellowCircle() {
        // Instantiate a yellow circle at the spawn point's position
        GameObject yellowCircle = Instantiate(yellowCirclePrefab, transform.position, Quaternion.identity);
        yellowCircle.GetComponent<CircleController>().type = CircleType.Yellow;
    }
}

