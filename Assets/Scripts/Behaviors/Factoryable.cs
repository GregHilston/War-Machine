using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dictates how to spawn a new processed material and despawns this one.
/// </summary>
public class Factoryable : MonoBehaviour {
    public void transformOneObjectIntoAnother(GameObject input, GameObject output, Vector3 outputPosition, Quaternion outputRotation, float processTime = 0.0f) {
        SimplePool.Despawn(input); // delete old one
        StartCoroutine(Invoker.Invoke(() => SimplePool.Spawn(output, outputPosition, outputRotation), processTime));
    }
}
