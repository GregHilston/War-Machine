using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Continuously Conveys Conveyable objects to the endpoint.
/// </summary>
public class Conveyor : MonoBehaviour {
    [SerializeField]
    [Tooltip("Where we should send the object to. Generally the point is past the Conveyor's point, so we don't stop moving on this GameObject.")]
    private Transform endpoint;
    [SerializeField]
    [Tooltip("How fast to move to the endpoint.")]
    private float speed;

    void OnCollisionStay(Collision collision) {
        var coveyable = collision.gameObject.GetComponent<Conveyable>();

        if (coveyable != null) {
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
