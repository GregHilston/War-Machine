using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Keeps track of how many of each type of item has touched it and despawned.
/// </summary>
public class GoalPlatform : MonoBehaviour {
    static Dictionary<string, int> despawnCount = new Dictionary<string, int>();

    private void IncrementCount(GameObject gameObject) {
        int currentCount;
        string originalPrefabName = SimplePool.GetOriginalPrefabName(gameObject);

        GoalPlatform.despawnCount.TryGetValue(originalPrefabName, out currentCount);
        GoalPlatform.despawnCount[originalPrefabName] = currentCount + 1;
    }

    private void OnCollisionEnter(Collision collision) {
        var despawnable = collision.gameObject.GetComponent<Despawnable>();
        if (despawnable != null) {
            this.IncrementCount(despawnable.gameObject);

            despawnable.despawn();
        }
    }
}
