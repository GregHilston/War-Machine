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

    // Start is called before the first frame update
    void Start() {
        print("Attempting to load " + SceneManager.GetActiveScene().name + "'s respective ScriptableObject");

        LevelData levelData = this.levelData[0]; // TODO unhard code the 0th index

        if (levelData != null) {
            print(levelData);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
