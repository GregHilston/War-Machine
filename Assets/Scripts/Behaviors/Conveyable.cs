using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves this object towards a destination, at a given speed.
/// </summary>
public class Conveyable : MonoBehaviour {
    public void convey (GameObject destination, float speed) {
       this.transform.position = Vector3.MoveTowards(this.transform.position, destination.transform.position, speed * Time.deltaTime);
    }
}
