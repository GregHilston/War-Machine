using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour {
    public void teleport(GameObject destination) {
        this.transform.position = destination.transform.position;
    }
}