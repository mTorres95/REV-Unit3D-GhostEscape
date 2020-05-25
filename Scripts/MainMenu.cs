using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Selecting "Play" in the Main Menu
    public void PlayGame () {
        PlayerPrefs.SetInt("PlayerScore", 0); // Tha player's score is initiated in the main menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Go to GameScene
    }

    // Selection "Quit" in the Main Menu
    public void QuitGame (){
        Debug.Log("QUIT");
        Application.Quit();
    }
}
