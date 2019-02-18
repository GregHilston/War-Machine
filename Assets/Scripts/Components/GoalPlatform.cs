using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps track of how many of each type of item has touched it and despawned.
/// </summary>
public class GoalPlatform : MonoBehaviour {
    static Dictionary<string, int> despawnCount = new Dictionary<string, int>();

    private void IncrementCount(GameObject gameObject) {
        int currentCount;
        GoalPlatform.despawnCount.TryGetValue(gameObject.GetType().ToString(), out currentCount);
        GoalPlatform.despawnCount[gameObject.GetType().ToString()] = currentCount + 1;

        Debug.Log(GoalPlatform.despawnCount[gameObject.GetType().ToString()] + " " + gameObject.GetType().ToString() + " have made it to GoalPlatform");
    }

    private void OnCollisionEnter(Collision collision) {
        var despawnable = collision.gameObject.GetComponent<Despawnable>();
        if (despawnable != null) {
            this.IncrementCount(despawnable.gameObject);

            despawnable.despawn();
        }
    }
}
