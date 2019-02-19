using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Keeps track of how many of each type of item has touched it and despawned.
/// </summary>
public class GoalPlatform : MonoBehaviour {


    private void OnCollisionEnter(Collision collision) {
        var despawnable = collision.gameObject.GetComponent<Despawnable>();
        if (despawnable != null) {
            despawnable.HappilyDespawn();
        }
    }
}
