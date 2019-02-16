using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factoryable : MonoBehaviour {
    public void transformOneObjectIntoAnother(GameObject input, GameObject output, Vector3 outputPosition, Quaternion outputRotation) {
        SimplePool.Spawn(output, outputPosition, outputRotation); // create new item before we lose reference to old one
        SimplePool.Despawn(input); // delete old one
    }
}
