using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles rotational changes by the user, applying the changes to the attach GameObject.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class RotationController : MonoBehaviour, IKeyCodeEventRespondable {
    public enum ThreeDAxis { X, Y, Z };

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
    [Tooltip("Axis to rotate on.")]
    public ThreeDAxis axisToRotateOn = ThreeDAxis.Y; // the Unity default for up and down

    void Start() {
        UserInputEventRouter.registerKeyboardResponder(this.rotateClockWiseKeyCode, KeyEvent.Pressed, this);
        UserInputEventRouter.registerKeyboardResponder(this.rotateCounterClockWiseKeyCode, KeyEvent.Pressed, this);
    }

    void OnDestroy() {
        UserInputEventRouter.deregisterKeyboardResponder(this.rotateClockWiseKeyCode, KeyEvent.Pressed, this);
        UserInputEventRouter.deregisterKeyboardResponder(this.rotateCounterClockWiseKeyCode, KeyEvent.Pressed, this);
    }

    // Returns the basic values, if it's 0 than its not active.
    private Vector3 GetBaseRotationInput(KeyCode keyCode) {
        Vector3 rotation = new Vector3();

        if (keyCode == this.rotateClockWiseKeyCode) {
            switch(this.axisToRotateOn) {
                case ThreeDAxis.X:
                    rotation = Vector3.left;
                    break;
                case ThreeDAxis.Y:
                    rotation = Vector3.down;
                    break;
                case ThreeDAxis.Z:
                    rotation = Vector3.back;
                    break;
            }
        } else if (keyCode == this.rotateCounterClockWiseKeyCode) {
            switch (this.axisToRotateOn) {
                case ThreeDAxis.X:
                    rotation = Vector3.right;
                    break;
                case ThreeDAxis.Y:
                    rotation = Vector3.up;
                    break;
                case ThreeDAxis.Z:
                    rotation = Vector3.forward;
                    break;
            }
        }

        return rotation;
    }

    bool IKeyCodeEventRespondable.respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent) {
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
