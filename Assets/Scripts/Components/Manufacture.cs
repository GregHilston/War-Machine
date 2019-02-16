using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manufacture : MonoBehaviour {
    public GameObject input;
    public GameObject output;
    public GameObject outputStage;
    public float processTime = 1.0f;

    private void OnCollisionEnter(Collision collision) {
        var manufactureable = collision.gameObject.GetComponent<Manufactureable>();

        if (manufactureable != null) {
            if (collision.gameObject.GetType() == input.GetType()) {
                manufactureable.transformOneObjectIntoAnother(manufactureable.gameObject, output, outputStage.transform.position, outputStage.transform.rotation);
            }
        }
    }
}
