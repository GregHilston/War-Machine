using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public GameObject launchPoint;
    public float thrust = 1000.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Launchable>() != null) {
            if (launchPoint != null) {
                collision.gameObject.transform.position = launchPoint.transform.position;
                collision.gameObject.transform.rotation = launchPoint.transform.rotation;

                collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.forward + collision.gameObject.transform.up) * thrust);
            }
        }
    }
}
