using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles despawning items.
/// </summary>
public class Despawnable : MonoBehaviour {
    public void despawn() {
        SimplePool.Despawn(this.gameObject);
    }
}