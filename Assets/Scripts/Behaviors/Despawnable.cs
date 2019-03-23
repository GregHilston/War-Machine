using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles despawning items.
/// </summary>
public class Despawnable : MonoBehaviour {
    public enum TypeOfDespawn {
        Happily,
        Angrily
    }

    /// <summary>
    /// Represents all objects that have been happily despawned.
    /// </summary>
    private static Dictionary<string, int> happyDespawnCount = new Dictionary<string, int>();
    /// <summary>
    /// Represents all objects that have been angerly despawned.
    /// </summary>
    private static Dictionary<string, int> angryDespawnCount = new Dictionary<string, int>();

    private void IncrementCount(Dictionary<string, int> dictionary) {
        int currentCount;
        string originalPrefabName = SimplePool.GetOriginalPrefabName(this.gameObject);

        // print("Despawner IncrementCount originalPrefabName " + originalPrefabName);

        dictionary.TryGetValue(originalPrefabName, out currentCount);
        dictionary[originalPrefabName] = currentCount + 1;
    }

    public void HappilyDespawn() {
        this.IncrementCount(Despawnable.happyDespawnCount);

        SimplePool.Despawn(this.gameObject);
    }

    public void AngrilyDespawn() {
        this.IncrementCount(Despawnable.angryDespawnCount);

        SimplePool.Despawn(this.gameObject);
    }
}