﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameMenuable))]
[RequireComponent(typeof(Pausable))]
public class GameMenuController : MonoBehaviour, IKeyCodeEventRespondable {
    [SerializeField]
    [Tooltip("Key to press down to show menu")]
    private KeyCode gameMenuKeyCode = KeyCode.Escape;
    private bool isGameMenuBeingShown = false;

    public void Start() {
        UserInputEventRouter.registerKeyboardResponder(this.gameMenuKeyCode, KeyEvent.Down, this);
    }

    private void toggleShowingGameMenuAndPausing() {
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

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit() {
        Application.Quit();
    }

    public bool respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent) {
        if (keyCode == this.gameMenuKeyCode) {
            this.toggleShowingGameMenuAndPausing();

            return true;
        }

        return false;
    }
}
