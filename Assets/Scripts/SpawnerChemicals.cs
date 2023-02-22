using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChemicals : MonoBehaviour
{
    public GameObject[] Chemicals;
    private float cooldownChemicals;
    private float chemicalsSpeed;
    private int secondsToIncreaseVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cooldownChemicals = 2f;
        chemicalsSpeed = -4.5f;
        secondsToIncreaseVelocity = 10;
        // Start the coroutine in order to spawn all kind of clouds
        StartCoroutine("SpawnerChemicalsFunction");
    }

    private IEnumerator SpawnerChemicalsFunction()
    {
        while (true)
        {
            if (secondsToIncreaseVelocity == 0)
            {
                cooldownChemicals -= 0.05f;
                secondsToIncreaseVelocity = 10;
            }
            else
            {
                secondsToIncreaseVelocity--;
                int cloudToInstantiate = Random.Range(0, Chemicals.Length);

                float randomY = Random.Range(2, 3.7f);
                GameObject newCloud = Instantiate(Chemicals[cloudToInstantiate], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                newCloud.GetComponent<Rigidbody2D>().velocity = new Vector2(chemicalsSpeed * Random.Range(1, 1.5f), 0);
            }
            yield return new WaitForSeconds(cooldownChemicals);
        }
    }
}
