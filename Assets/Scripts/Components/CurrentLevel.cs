using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel : MonoBehaviour {
    [SerializeField]
    [Tooltip("The level we are currently playing")]
    private LevelData levelData;

    public LevelData getLevelData {
        get {
            return this.levelData;
        }
    }
}
