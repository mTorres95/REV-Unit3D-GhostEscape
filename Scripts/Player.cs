using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int Score;
    public int HighScore;

    // Modify player's score and save it in the persistent data
    void AddScore(){
        Score++;
        PlayerPrefs.SetInt("PlayerScore",Score);
    }

    // To move the cube a bit faster
    [SerializeField]           // Shows up in the inspector
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Get in the variables the values from the persistent data
        Score = PlayerPrefs.GetInt("PlayerScore");
        HighScore = PlayerPrefs.GetInt("HighScore", 0);   
    }

    // FixedUpdate stops the player from "vibrating" when colliding
    // with an object and partially going "in" that objet
    void FixedUpdate()
    {
        // Get the user's arrow keys
        float horizontal = Input.GetAxis("Horizontal");        
        float vertical = Input.GetAxis("Vertical");
        
        // Using only x and z, doesn't change in y (higher or lower than the plane) 
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // (*Time.delta) to be independant of the frames
        transform.position += movement * Time.deltaTime * speed;
    }

    // Cube (player) dies when touched by ghosts (capsule) and wins when touching the goal
    private void OnCollisionEnter(Collision collision)    //call when sth touches the Box Collider 
    {
        if(collision.collider.tag == "Ghost"){
            SceneManager.LoadScene(2); // it's going to load the score scene
        }

        // Each time the player reaches the goal, it adds to its score and reloads the game
        if(collision.collider.tag == "Goal"){
            AddScore();
            // Verify if HighScore
            if(Score > PlayerPrefs.GetInt("HighScore", 0)){
                PlayerPrefs.SetInt("HighScore", Score);  // Make data persistant from one game session to another
            }
            SceneManager.LoadScene(1); // it's going to load the game scene
        }
    }
}
