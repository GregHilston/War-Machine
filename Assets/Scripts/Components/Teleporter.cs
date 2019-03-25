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
        if (collision.gameObject.GetComponent<Teleportable>() != null) {
            collision.gameObject.GetComponent<Teleportable>().teleportAndZeroOutForce(location);
        }
    }
}
