using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {
    public GameObject outputStage1;
    public GameObject outputStage2;
    public float processTime = 1.0f;
    private bool shouldGoToOutput1 = true;

    private void OnCollisionEnter(Collision collision) {
        var splittable = collision.gameObject.GetComponent<Splittable>();
        if (splittable != null) {
            var teleportable = collision.gameObject.GetComponent<Teleportable>();
            if (teleportable != null) {
                if (shouldGoToOutput1) {
                    teleportable.teleportAndZeroOutForce(outputStage1);
                } else {
                    teleportable.teleportAndZeroOutForce(outputStage2);
                }

                shouldGoToOutput1 = !shouldGoToOutput1;
            }

        }
    }
}