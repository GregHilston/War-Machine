using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Represents all the data for a level that can be played by a player.
/// </summary>
[CreateAssetMenu(fileName = "New LevelData", menuName = "LevelData", order = 51)]
public class LevelData : ScriptableObject {
    [System.Serializable]
    public struct Item {
        public string name;
        public int amount; 
    }

    [SerializeField]
    [Tooltip("The name of the level.")]
    private string levelName;
    [SerializeField]
    [Tooltip("The description of the level.")]
    private string description;
    // Unfortunately I have to do the following, as SerializeField does not support 
    // Dictionaries by default. See https://docs.unity3d.com/ScriptReference/SerializeField.html
    [SerializeField]
    [Tooltip("The items needed to win the level.")]
    private List<Item> goodItems = new List<Item>();
    [SerializeField]
    [Tooltip("The items needed to lose the level.")]
    private List<Item> badItems = new List<Item>();
    [SerializeField]
    [Tooltip("Player buildings not allowed on this level")]
    private List<GameObject> bannedPlayerBuildings = new List<GameObject>();

    public string LevelName {
        get {
            return this.levelName;
        }
    }

    public string Description {
        get {
            return this.description;
        }
    }

    public List<Item> GoodItems {
        get {
            return this.goodItems;
        }
    }

    public List<Item> BadItems {
        get {
            return this.badItems;
        }
    }

    public List<GameObject> BannedPlayerBuildings {
        get {
            return this.bannedPlayerBuildings;
        }
    }

    public override string ToString() {
        return this.levelName + ": " + this.description;
    }
}