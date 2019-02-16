using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {
    public Transform endpoint;
    public float speed;

    void OnCollisionStay(Collision collision) {
        var coveyable = collision.gameObject.GetComponent<Conveyable>();

        if (coveyable) {
            coveyable.convey(this.endpoint.gameObject, speed);
        }
    }

    void OnDrawGizmos() {
        if (endpoint != null) {
            Gizmos.color = Color.blue;

            Vector3 startPosition = transform.position;
            startPosition.y = 1.0f;

            Vector3 endPosition = endpoint.position;
            endPosition.y = 1.0f;

            Gizmos.DrawLine(startPosition, endPosition);
        }
    }
}
