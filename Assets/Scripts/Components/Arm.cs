using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves Armable objects from one position to another.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Arm : MonoBehaviour {
    [SerializeField]
    [Tooltip("Reference to the parent empty game object, so this arm can control animations for all the child objects.")]
    private Transform armParent;
    private Collider holding;
    private Vector3 previousScale;
    private GameObject lastCollidedWith;
    /// <summary>
    /// Dependency: The animator we use to trigger different animation states.
    /// </summary>
    private Animator animator; 

    void Awake() {
        this.animator = armParent.GetComponent<Animator>();
    }

    void Update() {
        if (this.animator != null) {
            if (holding != null && animator.GetCurrentAnimatorStateInfo(0).IsName("ArmRotated")) {
                animator.SetBool("CaughtItem", false);
                holding.transform.parent = null;
                holding.gameObject.transform.localScale = previousScale;
                holding = null;
            }
        }
    }

    private void OnTriggerEnter(Collider col) {
        if (this.animator != null && (animator.GetCurrentAnimatorStateInfo(0).IsName("UnRotated") || animator.GetCurrentAnimatorStateInfo(0).IsName("ArmStill"))) {
            var armable = col.GetComponent<Armable>();
            if (armable != null && holding == null && col.gameObject != lastCollidedWith) {
                holding = col;
                lastCollidedWith = col.gameObject;
                previousScale = col.gameObject.transform.localScale;

                col.transform.SetParent(gameObject.transform, true);
                animator.SetBool("CaughtItem", true);
            }
        }
    }
}
