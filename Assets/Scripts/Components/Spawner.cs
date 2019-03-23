using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns game objects of type objectToSpawn at this GameObject's position, every repeatEverySeconds starting at startAtSeconds.
/// </summary>
public class Spawner : MonoBehaviour {
    [SerializeField]
    [Tooltip("Which object should Spawner continuously spawn.")]
    private Item itemToSpawn;
    [SerializeField]
    [Tooltip("How many seconds should Spawner wait before we start spawning.")]
    private float startAtSeconds = 0.0f;
    [SerializeField]
    [Tooltip("How many seconds should Spawner wait before creating another objectToSpawn.")]
    private float repeatEverySeconds = 1.0f;
    [SerializeField]
    [Tooltip("LevelInformation to pass to the Items we spawn")]
    LevelInformation levelInformation;

    void Start() {
        InvokeRepeating("CreateObject", startAtSeconds, repeatEverySeconds);
    }

    void CreateObject() {
        GameObject objectSpawned = SimplePool.Spawn(itemToSpawn.gameObject, transform.position, transform.rotation);

        itemToSpawn.AddDependency(this.levelInformation);
    }
}
