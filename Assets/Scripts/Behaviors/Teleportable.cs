using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves this object to a new location.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Teleportable : MonoBehaviour {
    private void zeroOutForce() {
        var myRigidBody = this.GetComponent<Rigidbody>();
        if (myRigidBody != null) {
            // zeroring out any forces
            myRigidBody.velocity = Vector3.zero;
            myRigidBody.angularVelocity = Vector3.zero;
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