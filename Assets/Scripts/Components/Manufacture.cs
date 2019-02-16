using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manufacture : MonoBehaviour {
    public GameObject input;
    public GameObject output;
    public GameObject outputStage;
    public float processTime = 1.0f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Manufactureable>() != null) {
            if (collision.gameObject.GetType() == input.GetType()) {
                SimplePool.Spawn(output, outputStage.transform.position, outputStage.transform.rotation); // create new item before we lose reference to old one
                SimplePool.Despawn(collision.gameObject); // delete old one
            }
        }
    }
}
