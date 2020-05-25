using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    public Text highScore;
    public Text playerScore;

    // Show the player's score for that game and the HighScore 
    void Start() {
        playerScore.text = PlayerPrefs.GetInt("PlayerScore",0).ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); // If there's no persistant data, default value is 0
    }

    // Select "Back" in the HighScore Menu
    public void GoToMainMenu () {
        SceneManager.LoadScene(0);
    }
}
