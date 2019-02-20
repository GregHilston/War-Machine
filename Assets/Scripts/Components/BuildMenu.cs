using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BuildMenu : MonoBehaviour {
    [SerializeField]
    [Tooltip("Basic Button prefab to act as a basis of instantiation")]
    GameObject buttonPrefab;
    [SerializeField]
    [Tooltip("Button to base all children buttons off of.")]
    GameObject parentButton;
    private bool activateChildrenButtons = false;
    private List<string> playerBuildingPrefabs = new List<string>();
    private List<GameObject> childButtons = new List<GameObject>();

    private void fetchPlayerBuildingPrefabs() {
        string filePath = "Assets/Resources/Prefabs/Player Buildings";
        string metaExtension = ".meta";
        DirectoryInfo dir = new DirectoryInfo(filePath);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info) {
            if (!f.Name.EndsWith(metaExtension)) {
                this.playerBuildingPrefabs.Add(f.Name);
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
                                                        parentButton.transform.position.y + iOneBasedForMultiplication * 30.0f, 
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