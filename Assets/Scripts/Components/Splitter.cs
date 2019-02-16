using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {
    [SerializeField]
    [Tooltip("Location where half the output should go.")]
    private GameObject outputStage1;
    [SerializeField]
    [Tooltip("Other location where other half the output should go.")]
    private GameObject outputStage2;
    [SerializeField]
    [Tooltip("How long should Splitter taker to split a single object.")]
    private float processTime = 0.0f;
    private bool shouldGoToOutput1 = true; // used to track which output stage to move the object to

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