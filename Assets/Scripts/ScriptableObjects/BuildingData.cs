using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents all the data for a building that can be played by a player or by the level designer.
/// </summary>
[CreateAssetMenu(fileName = "New BuildingData", menuName = "BuildingData", order = 51)]
public class BuildingData : ScriptableObject {
    [SerializeField]
    [Tooltip("The name of this building")]
    private string name;

    [SerializeField]
    [Tooltip("The tooltip text that will be displayed when highlighting this building to place in the build menu.")]
    private string toolTip;

    [SerializeField]
    [Tooltip("The building that will be placed")]
    private GameObject prefab;

    public string Name {
        get {
            return this.name;
        }
    }

    public string ToolTip {
        get {
            return this.toolTip;
        }
    }

    public GameObject Prefab {
        get {
            return this.prefab;
        }
    }

    public override string ToString() {
        return this.name;
    }
}
