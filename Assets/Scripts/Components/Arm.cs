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
    private Animator animator;
    private Collider holding;

    void Start() {
        var animator = armParent.GetComponent<Animator>();
        if (animator != null) {
            this.animator = animator;
        }
    }

    void Update() {
        if (holding != null && animator.GetCurrentAnimatorStateInfo(0).IsName("ArmRotated")) {
            animator.SetBool("CaughtItem", false);
            holding.transform.parent = null;
            holding = null;
        }
    }

    private void OnTriggerEnter(Collider col) {
        var armable = col.GetComponent<Armable>();
        if (armable != null) {
            holding = col;

            col.transform.SetParent(gameObject.transform, true);
            animator.SetBool("CaughtItem", true);
        }
    }
}
