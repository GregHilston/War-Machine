using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Applies a govem force onto this object.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Launchable : MonoBehaviour {
    private Rigidbody rigidBody;

    public void Awake() {
        this.rigidBody = this.GetComponent<Rigidbody>();
    }

    public void launch(Vector3 force) {
        if (this.rigidBody != null) {
            this.rigidBody.AddForce(force);
        }
    }

    public void launch(Vector3 force, float processTime) {
        StartCoroutine(Invoker.Invoke(() => this.launch(force), processTime));
    }
}