using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupMovements : MonoBehaviour
{
    public float speed = 0.0f;
    private Vector2 direction; //holds the direction of movement
    private Rigidbody2D rb2d; //to apply force to pickup object

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f)).normalized; //generate
        //random number between -10 and 10, normalize 2D vector containing that random number, move in random directions
        SetSpeedByDifficulty(); //sets a different speed based on selected difficulty
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = direction * speed; //to make pickup object move smoother
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal); //to make pickup object bounce off walls
        }
    }

    public void SetSpeedByDifficulty()
    {
        speed = DifficultyManager.speedMultiplier; //set speed based on selected difficulty
    }
}
