using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.
Converted to C# 27-02-13 - no credit wanted.
Reformatted and cleaned by Ryan Breaker 23-6-18
Original comment:
Simple flycam I made, since I couldn't find any others made public.
Made simple to use (drag and drop, done) for regular keyboard layout.
Controls:
WASD  : Directional movement
Shift : Increase speed
Space : Moves camera directly up per its local Y-axis
*/
public class RotationController : MonoBehaviour { 
public float mainSpeed = 10.0f;   // Regular speed
    public float shiftAdd = 25.0f;   // Amount to accelerate when shift is pressed
    public float maxShift = 100.0f;  // Maximum speed when holding shift
    public float camSens = 0.15f;   // Mouse sensitivity

    // For zooming in and out with scroll wheel
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    private Vector3 lastMouse = new Vector3(255, 255, 255);  // kind of in the middle of the screen, rather than at the top (play)
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
