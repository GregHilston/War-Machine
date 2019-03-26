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
    private static Dictionary<GameObject, int> happyDespawnCount = new Dictionary<GameObject, int>();
    /// <summary>
    /// Represents all objects that have been angerly despawned.
    /// </summary>
    private static Dictionary<GameObject, int> angryDespawnCount = new Dictionary<GameObject, int>();

    private void IncrementCount(Dictionary<GameObject, int> dictionary) {
        int currentCount;
        
        dictionary.TryGetValue(this.gameObject, out currentCount);
        dictionary[this.gameObject] = currentCount + 1;
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