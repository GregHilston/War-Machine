using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LevelInformation : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI levelName;
    [SerializeField]
    private TextMeshProUGUI levelDescription;
    [SerializeField]
    private TextMeshProUGUI goodItems;
    [SerializeField]
    private TextMeshProUGUI badItems;
    [SerializeField]
    [Tooltip("Reference to progress in game.")]
    private LevelProgress levelProgress;

    public string ItemListToString(List<LevelData.RequiredItemData> requiredItemData) {
        string s = "";

        foreach (LevelData.RequiredItemData item in requiredItemData) {
            s += item.amount + " " + item.itemData.name + "\n";
        }

        return s;
    }

    static public Dictionary<ItemData, int> ItemListToDictionary(List<LevelData.RequiredItemData> items) {
        Dictionary<ItemData, int> itemData = new Dictionary<ItemData, int>();

        foreach (LevelData.RequiredItemData requiredItemData in items) {
            itemData.Add(requiredItemData.itemData, requiredItemData.amount);
        }

        return itemData;
    }

    public void UpdateDisplayUI(CurrentLevel currentLevel) {
        levelName.text = "Name: " + currentLevel.getLevelData.LevelName;
        levelDescription.text = "Description: " + currentLevel.getLevelData.Description;
        goodItems.text = "Pass Level: " + this.ItemListToString(currentLevel.getLevelData.GoodItems);
        badItems.text = "Fail Level: " + this.ItemListToString(currentLevel.getLevelData.BadItems);
    }

    public void UpdateDisplayUIWithLevelProgress() {
        // Debug.Log("UpdateDisplayUIWithLevelProgress");

        goodItems.text = "Pass Level: ";

        foreach(KeyValuePair<ItemData, int> entry in this.levelProgress.initialGoodItems) {
            goodItems.text += "\n\t" + this.levelProgress.liveGoodItems[entry.Key] + " of " + this.levelProgress.initialGoodItems[entry.Key] + " " + entry.Key;
        }

        badItems.text = "Fail Level: ";

        foreach (KeyValuePair<ItemData, int> entry in this.levelProgress.initialBadItems) {
            badItems.text += "\n\t" + this.levelProgress.liveBadItems[entry.Key] + " of " + this.levelProgress.initialBadItems[entry.Key] + " " + entry.Key;
        }
    }
}
