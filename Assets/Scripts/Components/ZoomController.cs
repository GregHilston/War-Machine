using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles zoomable changes by the user, applying the changes to the Main Camera.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class ZoomController : MonoBehaviour {
    [SerializeField]
    [Tooltip("The minimum field of field the ZoomController should allow.")]
    private float minFov = 15f;
    [SerializeField]
    [Tooltip("The maximum field of field the ZoomController should allow.")]
    private float maxFov = 90f;
    [SerializeField]
    [Tooltip("How sensitive ZoomController should be to zooming.")]
    private float sensitivity = 10f;
    
    void Update() {
        // Handle zooming in and out
        // From: https://answers.unity.com/questions/218347/how-do-i-make-the-camera-zoom-in-and-out-with-the.html
        var fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -1 * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
