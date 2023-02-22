using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    public GameObject background;
    public GameObject background2;
    private float backgroundSpeed;
    private int secondsToIncreaseVelocity;

    // Changes the position of the background sprites when they reach a specific position
    // Sets the position to the right in order that it will appear again in the window
    void Update()
    {
        if (background.transform.position.x <= -20f)
        {
            background.transform.position = new Vector2(background.transform.position.x + 42.6f, background.transform.position.y);
        } else if (background2.transform.position.x <= -20f)
        {
            background2.transform.position = new Vector2(background2.transform.position.x + 42.6f, background2.transform.position.y);
        }
    }



    // Sets the background velocity to the left. That causes a movement feeling to the player
    void Start()
    {
        backgroundSpeed = -3f;
        secondsToIncreaseVelocity = 10;
        StartCoroutine("ScrollBackground");
    }

    // Every 'secondsToIncreaseVelocity' the background sprite movement is faster
    private IEnumerator ScrollBackground()
    {
        while (true)
        {
            if (secondsToIncreaseVelocity == 0)
            {
                secondsToIncreaseVelocity = 10;
            }
            else
            {
                secondsToIncreaseVelocity--;
                background.GetComponent<Rigidbody2D>().velocity = new Vector2(backgroundSpeed - 0.05f, 0);
                background2.GetComponent<Rigidbody2D>().velocity = new Vector2(backgroundSpeed - 0.05f, 0);
            }
            yield return null;
        }
    }


}
