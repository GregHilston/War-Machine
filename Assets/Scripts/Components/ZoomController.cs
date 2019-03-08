using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles zoomable changes by the user, applying the changes to the Main Camera.
/// 
/// Based On: https://gist.github.com/RyanBreaker/932dc35302787d2f39df6b614a50c0c9 
/// </summary>
public class ZoomController : MonoBehaviour, IMouseEventRespondable {
    [SerializeField]
    [Tooltip("The minimum field of field the ZoomController should allow.")]
    private float minFov = 15f;
    [SerializeField]
    [Tooltip("The maximum field of field the ZoomController should allow.")]
    private float maxFov = 90f;
    [SerializeField]
    [Tooltip("How sensitive ZoomController should be to zooming.")]
    private float sensitivity = 10f;
    [SerializeField]
    [Tooltip("Axis to scroll on")]
    string axisToScrollOn = "Mouse ScrollWheel";

    void Start() {
        UserInputEventRouter.registerMouseResponder(this.axisToScrollOn, this);
    }

    void OnDestroy() {
        UserInputEventRouter.deregisterMouseResponder(this.axisToScrollOn, this);
    }

    public bool respoundToMouseEvent(string mouseAxis, float delta) {
        // since we don't use Time.deltaTime, we'll have a conditional to not zoom if the game is paused
        float epsilon = 0.01F;
        if(System.Math.Abs(Time.timeScale) > epsilon) {
            // Handle zooming in and out
            // From: https://answers.unity.com/questions/218347/how-do-i-make-the-camera-zoom-in-and-out-with-the.html
            var fov = Camera.main.fieldOfView;
            fov += delta * -1 * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;

            Debug.Log("respoundToMouseEvent mouseAxis " + mouseAxis + " delta " + delta);

            return true;
        }

        return false;
    }
}
