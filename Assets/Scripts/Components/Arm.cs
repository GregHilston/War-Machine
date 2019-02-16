using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {
    public float speed;
    public Transform armParent;
    private Animator anim;
    private Collider holding;

    void Start() {
        anim = armParent.GetComponent<Animator>();
    }

    void Update() {
        if (holding != null && anim.GetCurrentAnimatorStateInfo(0).IsName("ArmRotated")) {
            anim.SetBool("CaughtItem", false);
            holding.transform.parent = null;
            holding = null;
        }
    }

    private void OnTriggerEnter(Collider col) {
        if (col.GetComponent<Armable>() != null) {
            holding = col;

            col.transform.SetParent(gameObject.transform, true);
            anim.SetBool("CaughtItem", true);
        }
    }
}
