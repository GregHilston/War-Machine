﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///  Keeps track at how close the player is to winning or losing a level.
/// </summary>
public class LevelProgress : MonoBehaviour {
    [SerializeField]
    [Tooltip("All the levels that we can play in the game")]
    private LevelData[] allLevelData;
    [SerializeField]
    [Tooltip("What event to raise when we load a level")]
    private GameEvent onLevelLoadedEvent;
    [SerializeField]
    [Tooltip("Initial or some progress has been made in game.")]
    private GameEvent onProgressUpdatedGameEvent;
    [SerializeField]
    [Tooltip("Refence to who can control showing and hiding menus.")]
    private GameMenuController gameMenuController;
    private LevelData currentLevelData;
    public Dictionary<string, int> initialGoodItems = new Dictionary<string, int>();
    public Dictionary<string, int> initialBadItems = new Dictionary<string, int>();
    public Dictionary<string, int> liveGoodItems = new Dictionary<string, int>();
    public Dictionary<string, int> liveBadItems = new Dictionary<string, int>();

    int SceneNameToIndex() {
        int index = int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]) - 1; // To convert 1 based to 0 based

        // print("Attempting to load " + SceneManager.GetActiveScene().name + "'s respective ScriptableObject at index " + index);

        return index;
    }

    void InitializeLiveData() {
        this.initialGoodItems = LevelInformation.ItemListToDictionary(this.currentLevelData.GoodItems);
        this.initialBadItems = LevelInformation.ItemListToDictionary(this.currentLevelData.BadItems);

        foreach (KeyValuePair<string, int> entry in this.initialGoodItems) {
            this.liveGoodItems.Add(entry.Key, 0);
        }

        foreach (KeyValuePair<string, int> entry in this.initialBadItems) {
            this.liveBadItems.Add(entry.Key, 0);
        }
    }

    // Start is called before the first frame update
    void Start() {
        this.currentLevelData = this.allLevelData[this.SceneNameToIndex()];

        if (this.currentLevelData != null) {
            // print(this.currentLevelData);

            onLevelLoadedEvent.Raise();
        }

        this.InitializeLiveData();

        onProgressUpdatedGameEvent.Raise();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public bool HasWonLevel() {
        foreach (KeyValuePair<string, int> entry in this.initialGoodItems) {
            if (this.liveGoodItems[entry.Key] < entry.Value) {
                return false;
            }
        }

        return true;
    }

    public bool HasLostLevel() {
        if (this.initialBadItems.Count > 0) {
            foreach (KeyValuePair<string, int> entry in this.initialBadItems) {
                if (this.liveBadItems[entry.Key] < entry.Value) {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    public void HandleDespawn(GameObject gameObjectAboutToBeDespawned, Despawnable.TypeOfDespawn typeOfDespawn) {
        string nameOfItemDespawned = gameObjectAboutToBeDespawned.transform.name.Split(' ')[0];
        // Debug.Log("HandleDespawn of " + nameOfItemDespawned);

        if (typeOfDespawn == Despawnable.TypeOfDespawn.Happily) {
            this.liveGoodItems[nameOfItemDespawned] += 1;
        } else if (typeOfDespawn == Despawnable.TypeOfDespawn.Angrily) {
            this.liveBadItems[nameOfItemDespawned] += 1;
        }

        if (this.HasWonLevel()) {
            Debug.Log("WON!");
            this.gameMenuController.ShowGameWonMenu();
        } else if (this.HasLostLevel()) {
            Debug.Log("LOST!");
        }

        onProgressUpdatedGameEvent.Raise();
    }
}
