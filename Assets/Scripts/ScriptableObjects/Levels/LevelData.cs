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
    public struct RequiredItemData {
        public ItemData itemData;
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
    private List<RequiredItemData> goodItems = new List<RequiredItemData>();
    [SerializeField]
    [Tooltip("The items needed to lose the level.")]
    private List<RequiredItemData> badItems = new List<RequiredItemData>();
    [SerializeField]
    [Tooltip("Player buildings allowed on this level")]
    private List<BuildingData> allowedPlayerBuildings = new List<BuildingData>();

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

    public List<RequiredItemData> GoodItems {
        get {
            return this.goodItems;
        }
    }

    public List<RequiredItemData> BadItems {
        get {
            return this.badItems;
        }
    }

    public List<BuildingData> AllowedPlayerBuildings {
        get {
            return this.allowedPlayerBuildings;
        }
    }

    public override string ToString() {
        return this.levelName + ": " + this.description;
    }
}