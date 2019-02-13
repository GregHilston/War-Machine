using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public GameObject barrel;
    public float thrust = 1000.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Launchable>() != null) {
            if (barrel != null) {
                collision.gameObject.transform.position = barrel.transform.position;
                collision.gameObject.transform.rotation = barrel.transform.rotation;

                collision.gameObject.GetComponent<Rigidbody>().AddForce(barrel.transform.up * thrust);
            }
        }
    }
}
