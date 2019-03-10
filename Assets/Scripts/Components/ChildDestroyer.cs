using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDestroyer : MonoBehaviour {
    [SerializeField]
    [Tooltip("Only destroy children of this object.")]
    GameObject deleteOnlyChildrenOf;
    [SerializeField]
    [Tooltip("Whether we have permission to destroy.")]
    bool permissionToDestroy = false;

    public void GrantPermission() {
        this.permissionToDestroy = true;
    }

    void Update() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.Log("Update");

        if (permissionToDestroy && Input.GetButtonDown("Fire1")) {
            Debug.Log("Fire1");

            if (Physics.Raycast(ray, out hit, 1000)) {
                Debug.Log("Raycast");

                if (GameObject.ReferenceEquals(hit.collider.transform.root.gameObject, this.deleteOnlyChildrenOf)) {
                    Debug.Log("Found a child building!");

                    foreach (Transform child in hit.collider.transform.root.gameObject.transform) {
                        GameObject.Destroy(child.gameObject);
                    }

                    Destroy(hit.collider.gameObject);
                } else {
                    Debug.Log("Did not find a child building!");
                }
            }
        }
    }
}