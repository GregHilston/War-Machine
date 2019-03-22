using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///  Keeps track at how close the player is to winning or losing a level.
/// </summary>
public class LevelProgress : MonoBehaviour {
    [SerializeField]
    private LevelData[] levelData;
    [SerializeField]
    private GameEvent onLevelLoaded;

    int SceneNameToIndex() {
        print("Attempting to load " + SceneManager.GetActiveScene().name + "'s respective ScriptableObject");

        return int.Parse(SceneManager.GetActiveScene().name.Split('_')[1]) - 1; // To convert 1 based to 0 based
    }

    // Start is called before the first frame update
    void Start() {
        LevelData levelData = this.levelData[this.SceneNameToIndex()];

        if (levelData != null) {
            print(levelData);

            onLevelLoaded.Raise();
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
