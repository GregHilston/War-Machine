using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teleports objects of type Teleportable to location.
/// </summary>
public class Teleporter : MonoBehaviour {
    [SerializeField]
    [Tooltip("Where Teleporter should teleport the collided object to.")]
    private GameObject location;
    [SerializeField]
    [Tooltip("How long Teleporter should take to telport the collided object to.")]
    private float processTime = 0.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Teleportable>() != null) {
            collision.gameObject.GetComponent<Teleportable>().teleportAndZeroOutForce(location);
        }
    }
}
