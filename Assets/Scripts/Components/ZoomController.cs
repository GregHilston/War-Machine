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
public class ZoomController : MonoBehaviour {
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
        // Handle zooming in and out
        // From: https://answers.unity.com/questions/218347/how-do-i-make-the-camera-zoom-in-and-out-with-the.html
        var fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -1 * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
