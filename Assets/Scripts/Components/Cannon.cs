using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public GameObject barrel;
    public float thrust = 1000.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Launchable>() != null) {
            if (barrel != null) {
                collision.gameObject.GetComponent<Teleportable>().teleportAndZeroOutForce(barrel.transform.position, barrel.transform.rotation);


                collision.gameObject.GetComponent<Launchable>().launch(barrel.transform.up * thrust);
            }
        }
    }
}
