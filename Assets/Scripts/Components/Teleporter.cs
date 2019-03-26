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

    private void OnCollisionEnter(Collision collision) {
        Teleportable teleportable = collision.gameObject.GetComponent<Teleportable>();
        if (teleportable != null) {
            teleportable.teleportAndZeroOutForce(location);
        }
    }
}
