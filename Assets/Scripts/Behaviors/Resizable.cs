using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resizes this object by scale multiplier.
/// </summary>
public class Resizable : MonoBehaviour {
    public void resize(GameObject gameObject, float multiplier) {
        gameObject.transform.localScale *= multiplier;
    }
}
