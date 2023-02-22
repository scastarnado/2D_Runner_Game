using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SpawnerClouds : MonoBehaviour
{

    // Create an array which will hold all types of clouds
    public GameObject[] clouds;
    private float cooldownClouds;
    private float cloudsSpeed;
    private int secondsToIncreaseVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cooldownClouds = 0.5f;
        cloudsSpeed = -4.5f;
        secondsToIncreaseVelocity = 10;
        // Start the coroutine in order to spawn all kind of clouds
        StartCoroutine("SpawnerCloudsFunction");
    }

    private IEnumerator SpawnerCloudsFunction() {
        while (true) {
            if (secondsToIncreaseVelocity == 0)
            {
                cooldownClouds -= 0.005f;
                secondsToIncreaseVelocity = 10;
            }
            else
            {
                secondsToIncreaseVelocity--;
                int cloudToInstantiate = Random.Range(0, clouds.Length);

                float randomY = Random.Range(2, 3.7f);
                GameObject newCloud = Instantiate(clouds[cloudToInstantiate], new Vector2(this.transform.position.x, randomY), Quaternion.identity);
                newCloud.GetComponent<Rigidbody2D>().velocity = new Vector2(cloudsSpeed * Random.Range(1, 1.5f), 0);
            }
            yield return new WaitForSeconds(cooldownClouds);
        }
    }
}
