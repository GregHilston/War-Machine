using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manufacture : MonoBehaviour {
    public GameObject input;
    public GameObject output;
    public GameObject outputStage;
    public float processTime = 1.0f;

    private void OnCollisionEnter(Collision collision) {
        // Debug.Log("Manufacture!");
        if (collision.gameObject.GetComponent<Manufactureable>() != null) {
            // Debug.Log("collion not null");

            // Debug.Log("looking for " + collision.gameObject.name);
            if (collision.gameObject.GetType() == input.GetType()) {
                // Debug.Log("found " + collision.gameObject.name);

                Instantiate(output, outputStage.transform.position, outputStage.transform.rotation); // create new item before we lose reference to old one
                Destroy(collision.gameObject); // delete old one
            }
        }
    }
}
