using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour {
    [SerializeField]
    [Tooltip("Where to place the resized object.")]
    public GameObject outputStage;
    [SerializeField]
    [Tooltip("How much to resize the object by. Less than 1.0 to shrink, greater than 1.0 to grow.")]
    public float scaleMultiplier = 0.75f;
    [SerializeField]
    [Tooltip("How long the Resizer to should take.")]
    public float processTime = 0.0f;

    private void OnCollisionEnter(Collision collision) {
        var resizeable = collision.gameObject.GetComponent<Resizable>();
        if (resizeable != null) {
            resizeable.resize(collision.gameObject, scaleMultiplier);
        }

        var teleporter = collision.gameObject.GetComponent<Teleportable>();
        if (teleporter != null) {
            teleporter.teleportAndZeroOutForce(outputStage);
        }
    }
}
