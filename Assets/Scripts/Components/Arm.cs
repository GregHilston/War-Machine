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
    private Animator anim;
    private Collider holding;

    void Start() {
        var animator = armParent.GetComponent<Animator>();
        if (animator != null) {
            this.anim = animator;
        }
    }

    void Update() {
        if (holding != null && anim.GetCurrentAnimatorStateInfo(0).IsName("ArmRotated")) {
            anim.SetBool("CaughtItem", false);
            holding.transform.parent = null;
            holding = null;
        }
    }

    private void OnTriggerEnter(Collider col) {
        var armable = col.GetComponent<Armable>();
        if (armable != null) {
            holding = col;

            col.transform.SetParent(gameObject.transform, true);
            anim.SetBool("CaughtItem", true);
        }
    }
}
