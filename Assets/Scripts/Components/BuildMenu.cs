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
        for (int i = 1; i <= this.playerBuildingPrefabs.Count; i++) {
            GameObject newButton = Instantiate(this.buttonPrefab) as GameObject;
            newButton.transform.SetParent(this.parentButton.transform, false);

            newButton.GetComponentInChildren<Text>().text = this.playerBuildingPrefabs[i];
            newButton.transform.SetParent(this.parentButton.transform, false);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.transform.position = new Vector3(parentButton.transform.position.x, parentButton.transform.position.y + i * this.transform.localScale.y, parentButton.transform.position.z);
        }
    }

    void Start() {
        this.fetchPlayerBuildingPrefabs();
        this.addPlayerBuildingPrefabButtonsDeactivated();
    }

    public void ToogleActivateChildrenButtons() {
        Debug.Log(playerBuildingPrefabs);
    }
}