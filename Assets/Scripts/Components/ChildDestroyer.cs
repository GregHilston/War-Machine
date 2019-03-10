using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDestroyer : MonoBehaviour {
    [SerializeField]
    [Tooltip("Only destroy children of this object")]
    GameObject deleteOnlyChildrenOf;

    void Update() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            if (GameObject.ReferenceEquals(hit.collider.GetComponentInParent<GameObject>(), this.deleteOnlyChildrenOf)) {
                Debug.Log("Found a child building!");
            }
        }
    }
}