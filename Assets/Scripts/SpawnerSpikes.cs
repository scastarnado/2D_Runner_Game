using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpikes : MonoBehaviour
{

    // Create an array which will hold all types of clouds
    public GameObject[] obstacles;
    private float cooldownObstacles;
    private float obstacleSpeed;
    private int secondsToIncreaseVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cooldownObstacles = 2.5f;
        obstacleSpeed = -4.5f;
        secondsToIncreaseVelocity = 10;
        // Start the coroutine in order to spawn all kind of obstacles
        StartCoroutine("SpawnerObstaclesFunction");
    }

    IEnumerator SpawnerObstaclesFunction()
    {
        while (true)
        {
            if (secondsToIncreaseVelocity == 0)
            {
                if (cooldownObstacles >= 1f)
                {
                    cooldownObstacles -= 0.5f;
                    secondsToIncreaseVelocity = 10;
                }
            }
            else
            {
                secondsToIncreaseVelocity--;
                int obstacleToInstantiate = Random.Range(0, obstacles.Length);

                GameObject newObstacle = Instantiate(obstacles[obstacleToInstantiate], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                newObstacle.GetComponent<Rigidbody2D>().velocity = new Vector2(obstacleSpeed, 0);

            }
            yield return new WaitForSeconds(cooldownObstacles);
        }

    }
}
