using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles positional changes by the user, applying the changes to the attach GameObject.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class PositionController : MonoBehaviour {
    [SerializeField]
    [Tooltip("Regular speed to move position.")]
    private float mainSpeed = 10.0f;
    [SerializeField]
    [Tooltip("Amount to accelerate movement of position when shift is pressed.")]
    private float shiftAdd = 25.0f;
    [SerializeField]
    [Tooltip("Maximum speed when holding shift.")]
    private float maxShift = 100.0f;
    [SerializeField]
    [Tooltip("Key code to move position North.")]
    private KeyCode movePositionNorthKeyCode = KeyCode.W;
    [SerializeField]
    [Tooltip("Key code to move position East.")]
    private KeyCode movePositionEastKeyCode = KeyCode.A;
    [SerializeField]
    [Tooltip("Key code to move position South.")]
    private KeyCode movePositionSouthKeyCode = KeyCode.S;
    [SerializeField]
    [Tooltip("Key code to move position West.")]
    private KeyCode movePositionWestKeyCode = KeyCode.D;
    [SerializeField]
    [Tooltip("Key code to speed up position.")]
    private KeyCode positionSpeedBoostKeyCode = KeyCode.LeftShift;
    private float totalRun = 1.0f;
    void Update() {
        // Translation Keyboard commands
        Vector3 translation = GetBaseTranslationInput();
        if (Input.GetKey(this.positionSpeedBoostKeyCode)) {
            totalRun += Time.deltaTime;
            translation *= totalRun * shiftAdd;
            translation.x = Mathf.Clamp(translation.x, -maxShift, maxShift);
            translation.y = Mathf.Clamp(translation.y, -maxShift, maxShift);
            translation.z = Mathf.Clamp(translation.z, -maxShift, maxShift);
        }
        else {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            translation *= mainSpeed;
        }

        translation *= Time.deltaTime;
        transform.Translate(translation);
    }

    // Returns the basic values, if it's 0 than it's not active.
    private Vector3 GetBaseTranslationInput() {
        Vector3 translation = new Vector3();

        if (Input.GetKey(movePositionNorthKeyCode)) {
            translation += new Vector3(0, 1, 0);
        } 

        if (Input.GetKey(movePositionEastKeyCode)) {
            translation += new Vector3(-1, 0, 0);
        } 

        if (Input.GetKey(movePositionSouthKeyCode)) {
            translation += new Vector3(0, -1, 0);
        } 

        if (Input.GetKey(movePositionWestKeyCode)) {
            translation += new Vector3(1, 0, 0);
        }

        return translation;
    }
}
