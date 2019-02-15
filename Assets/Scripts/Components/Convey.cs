﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convey : MonoBehaviour {
    public Transform endpoint;
    public float speed;

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.GetComponent<Conveyable>() != null) {
            collision.gameObject.GetComponent<Conveyable>().convey(this.endpoint.gameObject, speed);
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
