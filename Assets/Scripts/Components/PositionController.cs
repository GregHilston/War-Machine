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
public class PositionController : MonoBehaviour {
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
