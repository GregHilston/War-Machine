using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pausable))]
public class PauseGameController : MonoBehaviour {
    [SerializeField]
    [Tooltip("Key to press down to pause the game")]
    string pauseKey = "p";
    [SerializeField]
    [Tooltip("Text to show when paused")]
    Text pausedText;

    private bool isGamePaused = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(this.pauseKey)){
            this.isGamePaused = !this.isGamePaused;

            var pauseable = GetComponent<Pausable>();
            if (pauseable != null) {
                if (this.isGamePaused) {
                    pauseable.PauseGame();
                    pausedText.gameObject.SetActive(true);
                }
                else {
                    pauseable.ContinueGame();
                    pausedText.gameObject.SetActive(false);
                }
            }
        }
    }
}
