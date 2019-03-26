using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an Item that may be used in game.
/// </summary>
[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 51)]
public class ItemData : ScriptableObject {
    [SerializeField]
    [Tooltip("The name of this Item")]
    private string name;

    [SerializeField]
    [Tooltip("The item that will be placed")]
    private GameObject prefab;

    public string Name {
        get {
            return this.name;
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
