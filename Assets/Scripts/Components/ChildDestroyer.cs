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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (permissionToDestroy && Input.GetButtonDown("Fire1")) {
            if (Physics.Raycast(ray, out hit, 1000)) {
                PrefabParentPointer prefabParentPointer = hit.collider.GetComponentInParent(typeof(PrefabParentPointer)) as PrefabParentPointer;

                // Debug.Log("Clicked on " + hit.collider.name);
                // Debug.Log("Whose parent is " + hit.collider.transform.parent.name);
                // Debug.Log("Whose root is " + hit.collider.transform.root.name);
                // Debug.Log("Whose prefabParentPointer is " + prefabParentPointer);

                if (prefabParentPointer != null && hit.collider.transform.root.transform.name == this.deleteOnlyChildrenOf.transform.name) {
                    Destroy(prefabParentPointer.gameObject);
                    this.permissionToDestroy = false; // only delete one item
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