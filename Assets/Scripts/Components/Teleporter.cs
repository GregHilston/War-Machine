using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public GameObject location;
    public float processTime = 0.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Teleportable>() != null) {
            collision.gameObject.GetComponent<Teleportable>().teleportAndZeroOutForce(location);
        }
    }
}
