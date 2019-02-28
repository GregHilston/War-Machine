using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausable : MonoBehaviour {
    public void PauseGame() {
        Debug.Log("Paused");
        Time.timeScale = 0;
    }

    public void ContinueGame() {
        Debug.Log("Cotinued game");
        Time.timeScale = 1;
    }
}
