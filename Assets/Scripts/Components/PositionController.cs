using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles positional changes by the user, applying the changes to the attach GameObject.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class PositionController : MonoBehaviour {
    public float mainSpeed = 10.0f;   // Regular speed
    public float shiftAdd = 25.0f;   // Amount to accelerate when shift is pressed
    public float maxShift = 100.0f;  // Maximum speed when holding shift

    private float totalRun = 1.0f;

    void Update() {
        // Translation Keyboard commands
        Vector3 translation = GetBaseTranslationInput();
        if (Input.GetKey(KeyCode.LeftShift)) {
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

        // Forwards
        if (Input.GetKey(KeyCode.W)) {
            translation += new Vector3(0, 1, 0);
        }

        // Backwards
        if (Input.GetKey(KeyCode.S)) {
            translation += new Vector3(0, -1, 0);
        }

        // Left
        if (Input.GetKey(KeyCode.A)) {
            translation += new Vector3(-1, 0, 0);
        }

        // Right
        if (Input.GetKey(KeyCode.D)) {
            translation += new Vector3(1, 0, 0);
        }

        return translation;
    }
}
