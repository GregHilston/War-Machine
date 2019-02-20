using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BuildMenu : MonoBehaviour {
    [SerializeField]
    [Tooltip("Basic Button prefab to act as a basis of instantiation.")]
    private GameObject buttonPrefab;
    [SerializeField]
    [Tooltip("Button to base all children buttons off of.")]
    private GameObject parentButton;
    [SerializeField]
    [Tooltip("Relative folder to look at for content.")]
    private string filePath = "Assets/Resources/Prefabs/Player Buildings";
    [SerializeField]
    [Tooltip("We won't build dynamic buttons for files that end in this string.")]
    private string fileEndingsToIgnore = ".meta";
    [SerializeField]
    [Tooltip("We will remove this string from the end of the file to make a dynamic button text.")]
    private string fileEndingToRemove = ".prefab";
    private bool activateChildrenButtons = false;
    private List<string> playerBuildingPrefabs = new List<string>();
    private List<GameObject> childButtons = new List<GameObject>();
    private float buttonHeight = 30.0f;

    private void fetchPlayerBuildingPrefabs() {
        DirectoryInfo dir = new DirectoryInfo(filePath);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info) {
            if (!f.Name.EndsWith(this.fileEndingsToIgnore)) {
                this.playerBuildingPrefabs.Add(f.Name.Split(new[] { this.fileEndingToRemove }, StringSplitOptions.None)[0]);
            }
        }
    }

    private void addPlayerBuildingPrefabButtonsDeactivated() {
        for (int i = 0; i < this.playerBuildingPrefabs.Count; i++) {
            GameObject newButton = Instantiate(this.buttonPrefab) as GameObject;
            newButton.transform.SetParent(this.parentButton.transform, false);

            newButton.GetComponentInChildren<Text>().text = this.playerBuildingPrefabs[i];
            newButton.transform.SetParent(this.parentButton.transform, false);
            int iOneBasedForMultiplication = i + 1;
            newButton.transform.position = new Vector3(
                                                        parentButton.transform.position.x, 
                                                        parentButton.transform.position.y + iOneBasedForMultiplication * buttonHeight, 
                                                        parentButton.transform.position.z);

            newButton.SetActive(false); // hidden by default

            childButtons.Add(newButton);
        }
    }

    void Start() {
        this.fetchPlayerBuildingPrefabs();
        this.addPlayerBuildingPrefabButtonsDeactivated();
    }

    public void ToogleActivateChildrenButtons() {
        this.activateChildrenButtons = !this.activateChildrenButtons;

        foreach (GameObject button in this.childButtons) {
            button.SetActive(this.activateChildrenButtons);
        }
    }
}