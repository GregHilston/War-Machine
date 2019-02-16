using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launches Launchable objects.
/// </summary>
public class Cannon : MonoBehaviour {
    [SerializeField]
    [Tooltip("Reference to the barrel, where we'll actually launch an object out of.")]
    private GameObject barrel;
    [SerializeField]
    [Tooltip("How much force to apply to the object we're launching.")]
    private float thrust = 1000.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Launchable>() != null) {
            if (barrel != null) {
                collision.gameObject.GetComponent<Teleportable>().teleportAndZeroOutForce(barrel.transform.position, barrel.transform.rotation);

                collision.gameObject.GetComponent<Launchable>().launch(barrel.transform.up * thrust);
            }
        }
    }
}
