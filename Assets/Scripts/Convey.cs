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
}
