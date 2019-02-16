using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    [Tooltip("Which object should Spawner continuously spawn.")]
    public GameObject objectToSpawn;
    [SerializeField]
    [Tooltip("How many seconds should Spawner wait before we start spawning.")]
    public float startAtSeconds = 0.0f;
    [SerializeField]
    [Tooltip("How many seconds should Spawner wait before creating another objectToSpawn.")]
    public float repeatEverySeconds = 1.0f;

    void Start() {
        InvokeRepeating("CreateObject", startAtSeconds, repeatEverySeconds);
    }

    void CreateObject() {
        SimplePool.Spawn(objectToSpawn, transform.position, transform.rotation);
    }
}
