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

    public string ItemListToString(List<LevelData.Item> items) {
        string s = "";

        foreach (LevelData.Item item in items) {
            s += item.amount + " " + item.name + "\n";
        }

        return s;
    }

    public void UpdateDisplayUI(LevelData levelData) {
        levelName.text = "Name: " + levelData.LevelName;
        levelDescription.text = "Description: " + levelData.Description;
        goodItems.text = "Pass Level: " + this.ItemListToString(levelData.GoodItems);
        badItems.text = "Fail Level: " + this.ItemListToString(levelData.BadItems);
    }

}
