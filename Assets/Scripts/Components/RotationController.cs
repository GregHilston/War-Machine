using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles rotational changes by the user, applying the changes to the attach GameObject.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class RotationController : MonoBehaviour {
    [SerializeField]
    [Tooltip("Regular speed to move rotation.")]
    private float mainSpeed = 10.0f;
    [SerializeField]
    [Tooltip("Amount to accelerate movement of rotation when shift is pressed.")]
    private float shiftAdd = 25.0f;
    [SerializeField]
    [Tooltip("Maximum speed when holding shift.")]
    private float maxShift = 100.0f;
    private float totalRun = 1.0f;

    void Update() {
        // Rotation Keyboard commands
        Vector3 rotation = GetBaseRotationInput();
        if (Input.GetKey(KeyCode.LeftShift)) {
            totalRun += Time.deltaTime;
            rotation *= totalRun * shiftAdd;
            rotation.x = Mathf.Clamp(rotation.x, -maxShift, maxShift);
            rotation.y = Mathf.Clamp(rotation.y, -maxShift, maxShift);
            rotation.z = Mathf.Clamp(rotation.z, -maxShift, maxShift);
        }
        else {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            rotation *= mainSpeed;
        }

        rotation *= Time.deltaTime;
        transform.Rotate(rotation);
    }

    // Returns the basic values, if it's 0 than its not active.
    private Vector3 GetBaseRotationInput() {
        Vector3 rotation = new Vector3();

        // Counter Clockwise
        if (Input.GetKey(KeyCode.Q)) {
            rotation = Vector3.back;
        }

        // Clockwise
        if (Input.GetKey(KeyCode.E)) {
            rotation = Vector3.forward;
        }

        return rotation;
    }
}
