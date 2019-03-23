using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideGameObjectAble : MonoBehaviour {
    [SerializeField]
    [Tooltip("Parent Object to show or hide")]
    private GameObject gameParentObject;

    public void ShowParent() {
        Debug.Log("Showing");
        gameParentObject.SetActive(true);
    }

    public void HideParent() {
        Debug.Log("Hiding");
        gameParentObject.SetActive(false);
    }
}