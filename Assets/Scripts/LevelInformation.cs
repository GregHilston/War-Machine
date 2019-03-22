using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelInformation : MonoBehaviour {
    [SerializeField]
    private TextMeshPro levelName;
    [SerializeField]
    private TextMeshPro levelDescription;
    [SerializeField]
    private TextMeshPro goodItems;
    [SerializeField]
    private TextMeshPro badItems;

    public void UpdateDisplayUI(LevelData levelData) {
        levelName.text = levelData.LevelName;
        levelDescription.text = levelData.Description;
    }

}
