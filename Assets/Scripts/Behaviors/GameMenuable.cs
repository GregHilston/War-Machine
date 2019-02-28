using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuable : MonoBehaviour {
    [SerializeField]
    [Tooltip("Game Menu Parent Object to show or hide")]
    private GameObject gameMenuParentObject;

    public void ShowGameMenu() {
        Debug.Log("Showing Game Menu");
        gameMenuParentObject.SetActive(true);
    }

    public void HideGameMenu() {
        Debug.Log("Hiding Game Menu");
        gameMenuParentObject.SetActive(false);
    }
}