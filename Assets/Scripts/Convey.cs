using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convey : MonoBehaviour {
    public GameObject belt;
    public Transform endpoint;
    public float speed;

    void OnTriggerStay(Collider other) {
        if (other.GetComponent<Conveyable>() != null) {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
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
