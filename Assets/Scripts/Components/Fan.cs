using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a hitbox in front of the fan, applying a constant force on all objects that pass through.
/// </summary>
public class Fan : MonoBehaviour {
    [SerializeField]
    [Tooltip("How much force to apply to the object we're blowing.")]
    private float force = 1000.0f;

    private void OnCollisionEnter(Collision collision) {
        Launchable launchable = collision.gameObject.GetComponent<Launchable>();
        if (launchable != null) {
            launchable.launch(gameObject.transform.up * -1.0f * force);
        }
    }
}