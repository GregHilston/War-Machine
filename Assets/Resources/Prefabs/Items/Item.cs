using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    LevelInformation levelInformation;

    public void AddDependency(LevelInformation levelInformation) {
        this.levelInformation = levelInformation;
    }
}
