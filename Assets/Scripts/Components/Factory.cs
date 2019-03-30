using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Turns objects of type input, into type output, moving the newly created output to the outputStage.
/// </summary>
public class Factory : MonoBehaviour {
    [SerializeField]
    [Tooltip("What type of objects this Factory takes as input")]
    private GameObject input;
    [SerializeField]
    [Tooltip("What type of objects this Factory creates as output")]
    private GameObject output;
    [SerializeField]
    [Tooltip("Where this Factory should place its output")]
    private GameObject outputStage;
    [SerializeField]
    [Tooltip("How long it should take to Factory")]
    private float processTime = 0.0f;

    private void OnCollisionEnter(Collision collision) {
        Factoryable factoryable = collision.gameObject.GetComponent<Factoryable>()
        if (factoryable != null) {
            if (collision.gameObject.GetType() == input.GetType()) {
                factoryable.transformOneObjectIntoAnother(factoryable.gameObject, output, outputStage.transform.position, outputStage.transform.rotation, this.processTime);
            }
        }
    }
}
