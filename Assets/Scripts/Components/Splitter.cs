using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour {
    public GameObject outputStage1;
    public GameObject outputStage2;
    public float processTime = 1.0f;
    private bool shouldGoToOutput1 = true;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Splittable>() != null) {
            Vector3 intendedPosition;
            Quaternion intendedRotation;

            if (shouldGoToOutput1) {
                intendedPosition = outputStage1.transform.position;
                intendedRotation = outputStage1.transform.rotation;
            } else {
                intendedPosition = outputStage2.transform.position;
                intendedRotation = outputStage2.transform.rotation;
            }

            collision.gameObject.transform.position = intendedPosition;
            collision.gameObject.transform.rotation = intendedRotation;

            shouldGoToOutput1 = !shouldGoToOutput1;
        }
    }
}