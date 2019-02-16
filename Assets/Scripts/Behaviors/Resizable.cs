using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resizes this object by scale multiplier.
/// </summary>
public class Resizable : MonoBehaviour {
    public void resize(GameObject gameObject, float multiplier) {
        gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x * multiplier,
            gameObject.transform.localScale.y * multiplier,
            gameObject.transform.localScale.z * multiplier
        );
    }
}
