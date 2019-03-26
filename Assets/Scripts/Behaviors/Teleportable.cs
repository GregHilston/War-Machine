using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves this object to a new location.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Teleportable : MonoBehaviour {
    Rigidbody rigidbody;

    public void Awake() {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    private void zeroOutForce() {
        if (this.rigidbody != null) {
            // zeroring out any forces
            this.rigidbody.velocity = Vector3.zero;
            this.rigidbody.angularVelocity = Vector3.zero;
        }
    }

    public void teleportAndZeroOutForce(GameObject destination, float processTime) {
        this.transform.position = destination.transform.position;
        this.transform.rotation = destination.transform.rotation;

        zeroOutForce();
    }

    public void teleportAndZeroOutForce(GameObject destination) {
        this.transform.position = destination.transform.position;
        this.transform.rotation = destination.transform.rotation;

        zeroOutForce();
    }

    public void teleportAndZeroOutForce(Vector3 position, Quaternion rotation) {
        this.transform.position = position;
        this.transform.rotation = rotation;

        zeroOutForce();
    }
}