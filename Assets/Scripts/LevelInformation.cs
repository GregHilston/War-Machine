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

    public string ItemListToString(List<LevelData.Item> items) {
        string s = "";

        foreach (LevelData.Item item in items) {
            s += item.amount + " " + item.name + "\n";
        }

        return s;
    }

    static public Dictionary<string, int> ItemListToDictionary(List<LevelData.Item> items) {
        Dictionary<string, int> itemData = new Dictionary<string, int>();


        foreach (LevelData.Item item in items) {
            itemData.Add(item.name, item.amount);
        }

        return itemData;
    }

    public void UpdateDisplayUI(LevelData levelData) {
        levelName.text = "Name: " + levelData.LevelName;
        levelDescription.text = "Description: " + levelData.Description;
        goodItems.text = "Pass Level: " + this.ItemListToString(levelData.GoodItems);
        badItems.text = "Fail Level: " + this.ItemListToString(levelData.BadItems);
    }

    public void UpdateDisplayUIWithLevelProgress() {
        // Debug.Log("UpdateDisplayUIWithLevelProgress");

        goodItems.text = "Pass Level: ";

        foreach(KeyValuePair<string, int> entry in this.levelProgress.initialGoodItems) {
            goodItems.text += "\n\t" + this.levelProgress.liveGoodItems[entry.Key] + " of " + this.levelProgress.initialGoodItems[entry.Key] + " " + entry.Key;
        }

        badItems.text = "Fail Level: ";

        foreach (KeyValuePair<string, int> entry in this.levelProgress.initialBadItems) {
            badItems.text += "\n\t" + this.levelProgress.liveBadItems[entry.Key] + " of " + this.levelProgress.liveBadItems[entry.Key] + " " + entry.Key;
        }
    }
}
