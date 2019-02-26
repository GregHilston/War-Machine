using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuable : MonoBehaviour {
    [SerializeField]
    [Tooltip("Game Menu Parent Object to show or hide")]
    private GameObject gameMenuParentObject;

    public void ShowGameMenu() {
        gameMenuParentObject.SetActive(true);
    }

    public void HideGameMenu() {
        gameMenuParentObject.SetActive(false);
    }
}