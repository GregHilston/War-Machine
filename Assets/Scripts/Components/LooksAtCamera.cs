using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class LooksAtCamera : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        TextMeshPro textMesh = this.GetComponent<TextMeshPro>();

        if (textMesh) {
            textMesh.transform.position = gameObject.transform.position;

            PrefabParentPointer prefabParentPointer = GetComponentInParent<PrefabParentPointer>();

            if (prefabParentPointer) {
                textMesh.text = prefabParentPointer.name;
            }
        }
    }
}
