using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Keeps track of how many of each type of item has touched it and despawned.
/// </summary>
public class GoalPlatform : MonoBehaviour {
    [SerializeField]
    [Tooltip("Who to inform of a despawn")]
    LevelProgress levelProgress;

    private void OnCollisionEnter(Collision collision) {
        Despawnable despawnable = collision.gameObject.GetComponent<Despawnable>()
        if (despawnable != null) {
            if (this.levelProgress) {
                this.levelProgress.HandleDespawn(collision.gameObject, Despawnable.TypeOfDespawn.Happily);
            }

            despawnable.HappilyDespawn();
        }
    }
}
