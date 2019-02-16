using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies a govem force onto this object.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Launchable : MonoBehaviour {
    public void launch(Vector3 force) {
        var myRigidBody = this.GetComponent<Rigidbody>();
        if (myRigidBody != null) {
            myRigidBody.AddForce(force);
        }
    }
}