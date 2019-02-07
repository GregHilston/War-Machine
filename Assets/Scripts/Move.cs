using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed;
    private Animator anim;
    public Transform armParent;

    void Start()
    {
        anim = armParent.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("CaughtItem", !anim.GetBool("CaughtItem"));
        }
    }

    void OnTriggerStay(Collider other) {
        // this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(180, 0, 0), Time.deltaTime * speed);

        // other.transform.rotation = this.transform.rotation;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("FIRING!!");
        if (col.transform.tag.Equals("ConveyAble"))
        {
            col.transform.parent = gameObject.transform;
            anim.SetBool("CaughtItem", true);
        }
    }
}
