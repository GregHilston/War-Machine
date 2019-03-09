using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        // When you attempt to quit in game and it doesnt quit during unity development, you can prove that it would if you built the binary
        Debug.Log("Quit Game"); 
        Application.Quit();
    }
}
