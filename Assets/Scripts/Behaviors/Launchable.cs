using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Launchable : MonoBehaviour {
    public void launch(Vector3 force) {
        var myRigidBody = this.GetComponent<Rigidbody>();
        if (myRigidBody != null) {
            myRigidBody.AddForce(force);
        }
    }
}