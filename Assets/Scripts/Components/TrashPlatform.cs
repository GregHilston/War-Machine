using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPlatform : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        var despawnable = collision.gameObject.GetComponent<Despawnable>();
        if (despawnable != null) {
            despawnable.AngrilyDespawn();
        }
    }
}
