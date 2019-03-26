using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ShowHideGameObjectAble))]
[RequireComponent(typeof(Pausable))]
public class GameMenuController : MonoBehaviour, IKeyCodeEventRespondable {
    [SerializeField]
    [Tooltip("Key to press down to show menu")]
    private KeyCode gameMenuKeyCode = KeyCode.Escape;
    private bool isGameMenuBeingShown = false;
    /// <summary>
    /// Dependency: The pausable.
    /// </summary>
    private Pausable pauseable;

    public void Awake() {
        this.pauseable = GetComponent<Pausable>();
    }

    public void Start() {
        UserInputEventRouter.registerKeyboardResponder(this.gameMenuKeyCode, KeyEvent.Down, this);
    }

    private void toggleShowingGameMenuAndPausing() {
        this.isGameMenuBeingShown = !this.isGameMenuBeingShown;

        if (pauseable != null) {
            if (this.isGameMenuBeingShown) {

                pauseable.PauseGame();
            } else {
                pauseable.ContinueGame();
            }
        }

        var gameMenuable = GetComponent<ShowHideGameObjectAble>();
        if (gameMenuable != null) {
            if (this.isGameMenuBeingShown) {
                gameMenuable.ShowParent();
            } else {
                gameMenuable.HideParent();
            }
        }
    }

    public void ShowGameWonMenu() {
        // Hide game menu if it was being displayed when we won
        var gameMenuable = GetComponent<ShowHideGameObjectAble>();
        if (gameMenuable != null) {
            gameMenuable.HideParent();

        }

        // Don't want to be able to show more than one menu at once
        UserInputEventRouter.deregisterKeyboardResponder(this.gameMenuKeyCode, KeyEvent.Down, this);

        // Display win menu if it was being displayed when we won
        var winMenuable = GetComponents<ShowHideGameObjectAble>()[1];
        if (winMenuable != null) {
            winMenuable.ShowParent();

        }
    }

    public void ShowGameLostMenu() {
        // Hide game menu if it was being displayed when we won
        var gameMenuable = GetComponent<ShowHideGameObjectAble>();
        if (gameMenuable != null) {
            gameMenuable.HideParent();

        }

        // Don't want to be able to show more than one menu at once
        UserInputEventRouter.deregisterKeyboardResponder(this.gameMenuKeyCode, KeyEvent.Down, this);

        // Display win menu if it was being displayed when we won
        var loseMenuable = GetComponents<ShowHideGameObjectAble>()[2];
        if (loseMenuable != null) {
            loseMenuable.ShowParent();
        }
    }

    public void RestartCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
