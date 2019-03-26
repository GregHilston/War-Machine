using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///  Keeps track at how close the player is to winning or losing a level.
/// </summary>
public class LevelProgress : MonoBehaviour {
    [SerializeField]
    [Tooltip("What event to raise when we load a level")]
    private GameEvent onLevelLoadedEvent;
    [SerializeField]
    [Tooltip("Initial or some progress has been made in game.")]
    private GameEvent onProgressUpdatedGameEvent;
    [SerializeField]
    [Tooltip("Refence to who can control showing and hiding menus.")]
    private GameMenuController gameMenuController;
    [SerializeField]
    [Tooltip("Current Level component, that stores what we're playing")]
    private CurrentLevel currentLevel;
    public Dictionary<ItemData, int> initialGoodItems = new Dictionary<ItemData, int>();
    public Dictionary<ItemData, int> initialBadItems = new Dictionary<ItemData, int>();
    public Dictionary<ItemData, int> liveGoodItems = new Dictionary<ItemData, int>();
    public Dictionary<ItemData, int> liveBadItems = new Dictionary<ItemData, int>();

    void InitializeLiveData() {
        this.initialGoodItems = LevelInformation.ItemListToDictionary(this.currentLevel.getLevelData.GoodItems);
        this.initialBadItems = LevelInformation.ItemListToDictionary(this.currentLevel.getLevelData.BadItems);

        foreach (KeyValuePair<ItemData, int> entry in this.initialGoodItems) {
            this.liveGoodItems.Add(entry.Key, 0);
        }

        foreach (KeyValuePair<ItemData, int> entry in this.initialBadItems) {
            this.liveBadItems.Add(entry.Key, 0);
        }
    }

    // Start is called before the first frame update
    void Start() {
        if (this.currentLevel != null) {
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
        foreach (KeyValuePair<ItemData, int> entry in this.initialGoodItems) {
            if (this.liveGoodItems[entry.Key] < entry.Value) {
                return false;
            }
        }

        return true;
    }

    public bool HasLostLevel() {
        if (this.initialBadItems.Count > 0) {
            foreach (KeyValuePair<ItemData, int> entry in this.initialBadItems) {
                if (this.liveBadItems[entry.Key] < entry.Value) {
                    return false;
                }
            }

            return true;
        }

        return false;
    }

    public void HandleDespawn(GameObject gameObjectAboutToBeDespawned, Despawnable.TypeOfDespawn typeOfDespawn) {
        // A weird way to iterate over a dictionary and make changes, to protect ourselves from an out of sync error
        // See: https://stackoverflow.com/a/1070795/1983957
        List<ItemData> keysWhoseValueMayBeModified = new List<ItemData>(this.liveGoodItems.Keys);

        foreach (ItemData itemData in keysWhoseValueMayBeModified) {
            if (gameObjectAboutToBeDespawned.GetType() == itemData.Prefab.GetType()) {
                this.liveGoodItems[itemData] += 1;
            }
        }

        keysWhoseValueMayBeModified = new List<ItemData>(this.liveBadItems.Keys);
        foreach (ItemData itemData in keysWhoseValueMayBeModified) {
            if (gameObjectAboutToBeDespawned.GetType() == itemData.Prefab.GetType()) {
                this.liveBadItems[itemData] += 1;
            }
        }

        if (this.HasWonLevel()) {
            Debug.Log("WON!");
            this.gameMenuController.ShowGameWonMenu();
        } else if (this.HasLostLevel()) {
            this.gameMenuController.ShowGameLostMenu();
        }

        onProgressUpdatedGameEvent.Raise();
    }
}
