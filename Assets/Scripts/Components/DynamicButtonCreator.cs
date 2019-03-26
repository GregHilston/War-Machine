using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// Creates buttons dynamically by looking at files in some folder.
/// </summary>
[RequireComponent(typeof(BuildingPlacer))]
public class DynamicButtonCreator : MonoBehaviour {
    [SerializeField]
    [Tooltip("Basic Button prefab to act as a basis of instantiation.")]
    private GameObject buttonPrefab;
    [SerializeField]
    [Tooltip("Button to base all children buttons off of.")]
    private GameObject parentButton;
    private bool activateChildrenButtons = false;
    private List<BuildingData> allowedPlayerBuildings = new List<BuildingData>();
    private List<GameObject> childButtons = new List<GameObject>();
    private float buttonHeight = 30.0f;
    private BuildingPlacer buildingPlacer;
    [SerializeField]
    [Tooltip("Current Level component, that stores what we're playing")]
    private CurrentLevel currentLevel;

    private void fetchPlayerBuildingPrefabs() {
        if (this.currentLevel.getLevelData != null) {
            foreach (BuildingData buildingData in this.currentLevel.getLevelData.AllowedPlayerBuildings) {
                this.allowedPlayerBuildings.Add(buildingData);
            }
        }
    }

    private void addPlayerBuildingPrefabButtonsDeactivated() {
        for (int i = 0; i < this.allowedPlayerBuildings.Count; i++) {
            GameObject newButton = Instantiate(this.buttonPrefab) as GameObject;
            newButton.transform.SetParent(this.parentButton.transform, false);

            Text text = newButton.GetComponentInChildren<Text>();

            if (text != null) {
                text.text = this.allowedPlayerBuildings[i].Name;
            }

            newButton.transform.SetParent(this.parentButton.transform, false);
            int iOneBasedForMultiplication = i + 1;
            newButton.transform.position = new Vector3(
                                                        parentButton.transform.position.x, 
                                                        parentButton.transform.position.y + iOneBasedForMultiplication * buttonHeight, 
                                                        parentButton.transform.position.z);

            newButton.SetActive(false); // hidden by default

            int tempInt = i; // required so we can increment i without affected this tempInt
            Button button = newButton.GetComponent<Button>();

            if (button != null) {
                button.onClick.AddListener(() => BuildABuildingButtonClicked(tempInt));
            }

            childButtons.Add(newButton);
        }
    }

    void Start() {
        this.buildingPlacer = this.GetComponent<BuildingPlacer>();
        this.fetchPlayerBuildingPrefabs();
        this.addPlayerBuildingPrefabButtonsDeactivated();
    }
   
    public void ToogleActivateChildrenButtons() {
        this.activateChildrenButtons = !this.activateChildrenButtons;

        foreach (GameObject button in this.childButtons) {
            button.SetActive(this.activateChildrenButtons);
        }
    }

    void BuildABuildingButtonClicked(int buttonNo) {
        if (this.buildingPlacer != null) {
            this.buildingPlacer.buildingToCreate = this.allowedPlayerBuildings[buttonNo].Prefab;
        }
    }
}