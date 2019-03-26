using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class LooksAtCamera : MonoBehaviour {
    private TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start() {
        this.textMeshPro = this.GetComponent<TextMeshPro>();

        if (this.textMeshPro) {
            this.textMeshPro.transform.position = gameObject.transform.position;

            PrefabParentPointer prefabParentPointer = GetComponentInParent<PrefabParentPointer>();

            if (prefabParentPointer) {
                this.textMeshPro.text = prefabParentPointer.name;
            }
        }
    }
}
