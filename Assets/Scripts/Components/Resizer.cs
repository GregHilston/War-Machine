using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour {
    public GameObject outputStage;
    public float processTime = 1.0f;
    public float scaleMultiplier = 0.75f;

    private void OnCollisionEnter(Collision collision) {
        var resizeable = collision.gameObject.GetComponent<Resizable>();
        if (resizeable != null) {
            resizeable.resize(collision.gameObject, scaleMultiplier);
        }

        var teleporter = collision.gameObject.GetComponent<Teleportable>();
        if (teleporter != null) {
            teleporter.teleport(outputStage);
        }
    }
}
