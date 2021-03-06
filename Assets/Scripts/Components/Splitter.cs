using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilizies this GameObject as an input and moves all objects of type Splittable to outputStage1 and outputStage2, round robin style.
/// </summary>
public class Splitter : MonoBehaviour {
    [SerializeField]
    [Tooltip("Location where half the output should go.")]
    private GameObject outputStage1;
    [SerializeField]
    [Tooltip("Other location where other half the output should go.")]
    private GameObject outputStage2;
    private bool shouldGoToOutput1 = true; // used to track which output stage to move the object to

    private void OnCollisionEnter(Collision collision) {
        Splittable splittable = collision.gameObject.GetComponent<Splittable>();
        if (splittable != null) {
            Teleportable teleportable = collision.gameObject.GetComponent<Teleportable>();
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