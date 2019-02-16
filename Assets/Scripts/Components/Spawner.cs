using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject objectToSpawn;
    public float startAt = 0.0f;
    public float repeatEvery = 1.0f;

    void Start() {
        InvokeRepeating("CreateObject", startAt, repeatEvery);
    }

    void CreateObject() {
        SimplePool.Spawn(objectToSpawn, transform.position, transform.rotation);
    }
}
