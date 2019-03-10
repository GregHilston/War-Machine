using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDestroyer : MonoBehaviour, IKeyCodeEventRespondable {
    [SerializeField]
    [Tooltip("KeyCode to press down to cancel destroying")]
    private KeyCode cancelDestroyingKey = KeyCode.Escape;
    [SerializeField]
    [Tooltip("Only destroy children of this object.")]
    GameObject deleteOnlyChildrenOf;
    [SerializeField]
    [Tooltip("Whether we have permission to destroy.")]
    bool permissionToDestroy = false;

    public void GrantPermission() {
        this.permissionToDestroy = true;

        UserInputEventRouter.registerKeyboardResponder(this.cancelDestroyingKey, KeyEvent.Down, this);
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

                    foreach (Transform child in hit.collider.transform) {
                        GameObject.Destroy(child.gameObject);
                    }

                    Destroy(hit.collider.gameObject);
                } else {
                    Debug.Log("Did not find a child building!");
                }
            }
        }
    }

    public bool respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent) {
        if (keyCode == this.cancelDestroyingKey) {
            UserInputEventRouter.deregisterKeyboardResponder(this.cancelDestroyingKey, KeyEvent.Down, this);

            this.permissionToDestroy = false;

            return true;
        }

        return false;
    }
}