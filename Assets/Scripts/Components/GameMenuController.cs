using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameMenuable))]
[RequireComponent(typeof(Pausable))]
[RequireComponent(typeof(UserInputEventRouter))]
public class GameMenuController : MonoBehaviour, IRespondable {
    [SerializeField]
    [Tooltip("Key to press down to show menu")]
    private string gameMenuKey = "escape";
    private bool isGameMenuBeingShown = false;

    public void Start() {
        var userInputEventRouter = GetComponent<UserInputEventRouter>();

        if (userInputEventRouter != null) {
            userInputEventRouter.registerResponder(this.gameMenuKey, this);
        }
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
                Debug.Log("here");
                gameMenuable.ShowGameMenu();
            } else {
                gameMenuable.HideGameMenu();
            }
        }
    }

    public bool respond(string key) {
        Debug.Log("Attempting to respond to " + key);

        if (key == this.gameMenuKey) {
            this.toggleShowingGameMenuAndPausing();

            Debug.Log("Succeeded!");
            return true;
        }

        Debug.Log("Failed!");
        return false;
    }
}
