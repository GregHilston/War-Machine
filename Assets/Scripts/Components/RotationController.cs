using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles rotational changes by the user, applying the changes to the attach GameObject.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class RotationController : MonoBehaviour, IRespondable {
    [SerializeField]
    [Tooltip("Regular speed to move rotation.")]
    private float mainSpeed = 10.0f;
    [SerializeField]
    [Tooltip("Amount to accelerate movement of rotation when shift is pressed.")]
    private float shiftAdd = 25.0f;
    [SerializeField]
    [Tooltip("Maximum speed when holding shift.")]
    private float maxShift = 100.0f;
    [SerializeField]
    [Tooltip("Key code to rotate clockwise.")]
    private KeyCode rotateClockWiseKeyCode = KeyCode.E;
    [SerializeField]
    [Tooltip("Key code to rotate counter clockwise.")]
    private KeyCode rotateCounterClockWiseKeyCode = KeyCode.Q;
    [SerializeField]
    [Tooltip("Key code to speed up rotations.")]
    private KeyCode rotateSpeedBoostKeyCode = KeyCode.LeftShift;
    private float totalRun = 1.0f;

    void Start() {
        UserInputEventRouter.registerResponder(this.rotateClockWiseKeyCode, KeyEvent.Pressed, this);
        UserInputEventRouter.registerResponder(this.rotateCounterClockWiseKeyCode, KeyEvent.Pressed, this);
    }

    // Returns the basic values, if it's 0 than its not active.
    private Vector3 GetBaseRotationInput(KeyCode keyCode) {
        Vector3 rotation = new Vector3();

        if (keyCode == this.rotateClockWiseKeyCode) {
            rotation = Vector3.back;
        } else if (keyCode == this.rotateCounterClockWiseKeyCode) {
            rotation = Vector3.forward;
        }

        return rotation;
    }

    bool IRespondable.respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent) {
        Vector3 rotation = GetBaseRotationInput(keyCode);

        if (Input.GetKey(this.rotateSpeedBoostKeyCode)) {
            totalRun += Time.deltaTime;
            rotation *= totalRun * shiftAdd;
            rotation.x = Mathf.Clamp(rotation.x, -maxShift, maxShift);
            rotation.y = Mathf.Clamp(rotation.y, -maxShift, maxShift);
            rotation.z = Mathf.Clamp(rotation.z, -maxShift, maxShift);
        } else {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            rotation *= mainSpeed;
        }

        rotation *= Time.deltaTime;
        transform.Rotate(rotation);

        return true;
    }
}
