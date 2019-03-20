using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///  Keeps track at how close the player is to winning or losing a level.
/// </summary>
public class LevelProgress : MonoBehaviour {
    [System.Serializable]
    private class Progress {
        public string name;
        // public string description;
        // public IDictionary<string, int> win = new Dictionary<string, int>();
        // public IDictionary<string, int> lose = new Dictionary<string, int>();
    }

    // Start is called before the first frame update
    void Start() {
        string jsonFileName = SceneManager.GetActiveScene().name + ".json";
        string jsonFilePath = "Level_Rules/" + jsonFileName;

        print("Attempting to load " + jsonFilePath);

        Object jsonFile = Resources.Load(jsonFilePath);
        
        if (jsonFile != null) {
            // Progress progress = JsonUtility.FromJson<Progress>(jsonFile.text);
            // print(progress.name); // will print 'Steve'
            print(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
