using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float gameDuration = 60f; //stores maximum duration of game
    private Rigidbody2D rb2d; //to apply force to game object
    public float speed = 0.0f; 
    private float count; 
    private int seconds;
    public Text countText;
    public Text winText;
    public Text gameOverText;
    private bool gameActive = true;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0.0f;
        seconds = 0;
        countText.text = "Count: " + seconds.ToString();
        gameOverText.text = "";
        winText.text = "";
        gameActive = true; 
        restartButton.gameObject.SetActive(false); //makes restart button disappear
    }

    private void Update()
    {
        if (gameActive)
        {
            //count seconds
            count += Time.deltaTime;
            seconds = (int)count % 60;
            countText.text = "Count: " + seconds.ToString();
        }

        if (count >= gameDuration)
        {
            winText.text = "You win!";
            gameActive = false; // makes game end
            rb2d.velocity = Vector2.zero; //sets velocity to zero so that the player cannot move
            restartButton.gameObject.SetActive(true); //makes restart button appear
        }
    }
    // FixedUpdate is in sync with physics engine
    void FixedUpdate()
    {
        if (gameActive)
        {

            float moveHorizontal = Input.GetAxis("Horizontal"); //to move player left and right
            float moveVertical = Input.GetAxis("Vertical"); //to move player uo and down

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.velocity = movement * speed; //to make player movement easy to control
        } else
        {
            rb2d.velocity = Vector2.zero; //sets velocity to zero so that player cannot move
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))  //if the player gets hit by a pickup object
        {
            gameOverText.text = "Game Over!"; //game ends, player lost
            winText.text = "You lose :(";
            gameActive = false; 
            rb2d.velocity = Vector2.zero;
            restartButton.gameObject.SetActive(true); //makes restart button appear
        }
    }

    public void OnRestartButtonPress()
    {
        DifficultyManager.speedMultiplier = 1.0f; //resets speed multiplier to 1 for difficulty options upon restart
        SceneManager.LoadScene("SampleScene"); //resets scene
    }
}
