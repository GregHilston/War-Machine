using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRespondable {
    /// <summary>
    /// Responds to a key being pressed.
    /// </summary>
    /// <returns>Whether this event was properly handled.</returns>
    bool respoundToKeyCodeDown(KeyCode key);
}

public class UserInputEventRouter : MonoBehaviour {
    private static Dictionary<KeyCode, List<IRespondable>> keyToRespounderDictionary = new Dictionary<KeyCode, List<IRespondable>>();

    void Update() {
        foreach (KeyValuePair<KeyCode, List<IRespondable>> element in UserInputEventRouter.keyToRespounderDictionary) {
            // Debug.Log("Checking if " + element.Key + " was pressed down");

            if (Input.GetKeyDown(element.Key)) {
                for (int i = 0; i < element.Value.Count; i++) {
                    if (element.Value[i].respoundToKeyCodeDown(element.Key)) {
                        return;
                    }
                }
            }
        }
    }

    public static void registerResponder(KeyCode keyCode, IRespondable responsable) {
        // initial creation of a list
        if (!UserInputEventRouter.keyToRespounderDictionary.ContainsKey(keyCode)) {
            UserInputEventRouter.keyToRespounderDictionary[keyCode] = new List<IRespondable>();
        }

        UserInputEventRouter.keyToRespounderDictionary[keyCode].Add(responsable);
    }

    public static void deregisterResponder(KeyCode keyCode, IRespondable respondable) {
        if (UserInputEventRouter.keyToRespounderDictionary[keyCode] != null && UserInputEventRouter.keyToRespounderDictionary[keyCode].Contains(respondable)) {
            UserInputEventRouter.keyToRespounderDictionary[keyCode].Remove(respondable);
        }
    }
}