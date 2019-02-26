using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameMenuable))]
[RequireComponent(typeof(Pausable))]
public class GameMenuController : MonoBehaviour {
    [SerializeField]
    [Tooltip("Key to press down to show menu")]
    private string gameMenuKey = "escape";


    private bool isGameMenuBeingShown = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(this.gameMenuKey)) {
            this.isGameMenuBeingShown = !this.isGameMenuBeingShown;

            var pauseable = GetComponent<Pausable>();
            if (pauseable != null) {
                if (this.isGameMenuBeingShown) {
                    pauseable.PauseGame();
                } else {
                    pauseable.ContinueGame();
                }
            }

            var gameMenuable = GetComponent<GameMenuable>();
            if (gameMenuable != null) {
                if (this.isGameMenuBeingShown) {
                    gameMenuable.ShowGameMenu();
                } else {
                    gameMenuable.HideGameMenu();
                }
            }
        }
    }
}
