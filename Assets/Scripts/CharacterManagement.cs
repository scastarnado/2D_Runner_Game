using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://img.itch.zone/aW1nLzY2MTkzMDguZ2lm/original/TTcztu.gif

public class CharacterManagement : MonoBehaviour
{
    public GameObject scoreText;
    private int score = 0;
    public int jumpForce;
    private bool jumpAllowed;
    public TextMeshProUGUI textMeshProUGUI;
    public PlayerInformation playerScriptable;
    public GameObject Deathpanel;
    public AudioClip background;
    public AudioClip jumpSound;
    public AudioClip potionCollected;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // We grab the current skin selected in the TitleScreen and set it to our player SpriteRenderer
        //  through an ScriptableObject
        this.GetComponent<SpriteRenderer>().sprite = playerScriptable.getCurrentSkin();
        // Set our ability to jump to true on start
        jumpAllowed = true;
        // Get the AudioSource component to play sound effects on some actions such as jump or collecting potions
        audioSource = GetComponent<AudioSource>();
    }

    // Manage the JUMP of the player when Space key is pressed and the player is able to jump
    void Update()
    {
        if (Input.GetKeyDown("space") && jumpAllowed)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            // Play the Jump sound
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
        // Control and change the score if the player collects a Potion
        textMeshProUGUI.text = score.ToString();
        // Change the ScriptableObject in order to "send" the score as the cash the player has to buy new skins
        playerScriptable.setCoinsToBuyNewStuff(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with an obstacle, the player dies and stops playing. A death panel pops up
        if(collision.transform.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
            //GameOverDead(Deathpanel);
        }
        // If the player collides with a Potion, adds one point to the score and play a sound
        else if (collision.transform.tag == "Chemicals")
        {
            score++;
            audioSource.clip = potionCollected;
            audioSource.Play();
            Destroy(collision.gameObject);
        }
    }

    // Set active the death panel
    void GameOverDead(GameObject Deathpanel)
    {
        Deathpanel.SetActive(true);
    }

    // Sets the jump ability to true when the player touches the ground.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            jumpAllowed = true;
        }
    }

    // Sets the jump ability to false when the player touches the ground.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Floor")
        {
            jumpAllowed = false;
        }
    }
}
