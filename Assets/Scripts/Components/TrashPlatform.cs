using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPlatform : MonoBehaviour {
    [SerializeField]
    [Tooltip("Who to inform of a despawn")]
    LevelProgress levelProgress;

    private void OnCollisionEnter(Collision collision) {
        var despawnable = collision.gameObject.GetComponent<Despawnable>();
        if (despawnable != null) {
            if (levelProgress) {
                this.levelProgress.HandleDespawn(collision.gameObject, Despawnable.TypeOfDespawn.Angrily);
            }

            despawnable.AngrilyDespawn();
        }
    }
}
