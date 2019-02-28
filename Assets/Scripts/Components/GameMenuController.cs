﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameMenuable))]
[RequireComponent(typeof(Pausable))]
public class GameMenuController : MonoBehaviour, IRespondable {
    [SerializeField]
    [Tooltip("Key to press down to show menu")]
    private KeyCode gameMenuKeyCode = KeyCode.Escape;
    private bool isGameMenuBeingShown = false;

    public void Start() {
        UserInputEventRouter.registerResponder(this.gameMenuKeyCode, this);
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

    public bool respoundToKeyCodeDown(KeyCode keyCode) {

        if (keyCode == this.gameMenuKeyCode) {
            this.toggleShowingGameMenuAndPausing();

            return true;
        }

        return false;
    }
}
