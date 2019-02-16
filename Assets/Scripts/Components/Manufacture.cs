using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manufacture : MonoBehaviour {
    [SerializeField]
    [Tooltip("What type of objects this Manufacture takes as input")]
    private GameObject input;
    [SerializeField]
    [Tooltip("What type of objects this Manufacture creates as output")]
    private GameObject output;
    [SerializeField]
    [Tooltip("Where this Manufacture should place its output")]
    private GameObject outputStage;
    [SerializeField]
    [Tooltip("How long it should take to Manufacture")]
    private float processTime = 0.0f;

    private void OnCollisionEnter(Collision collision) {
        var manufactureable = collision.gameObject.GetComponent<Manufactureable>();

        if (manufactureable != null) {
            if (collision.gameObject.GetType() == input.GetType()) {
                manufactureable.transformOneObjectIntoAnother(manufactureable.gameObject, output, outputStage.transform.position, outputStage.transform.rotation);
            }
        }
    }
}
