using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour {
    public GameObject outputStage;
    public float processTime = 1.0f;
    public float downScaleMultiplyer = 0.75f;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<Resizable>() != null) {
            collision.gameObject.transform.localScale = new Vector3(
                collision.gameObject.transform.localScale.x * downScaleMultiplyer,
                collision.gameObject.transform.localScale.y * downScaleMultiplyer,
                collision.gameObject.transform.localScale.z * downScaleMultiplyer
            );
            collision.gameObject.transform.position = outputStage.transform.position;
        }
    }
}
