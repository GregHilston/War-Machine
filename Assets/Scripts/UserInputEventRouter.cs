using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRespondable {
    /// <summary>
    /// Responds to a key being pressed.
    /// </summary>
    /// <returns>Whether this event was properly handled.</returns>
    bool respond(string key);
}

public class UserInputEventRouter : MonoBehaviour {
    private static Dictionary<string, List<IRespondable>> keyToRespounderDictionary = new Dictionary<string, List<IRespondable>>();

    void Update() {
        foreach (KeyValuePair<string, List<IRespondable>> element in UserInputEventRouter.keyToRespounderDictionary) {
            // Debug.Log("Checking if " + element.Key + " was pressed down");

            if (Input.GetKeyDown(element.Key)) {
                for (int i = 0; i < element.Value.Count; i++) {
                    if (element.Value[i].respond(element.Key)) {
                        return;
                    }
                }
            }
        }
    }

    public static void registerResponder(string key, IRespondable responsable) {
        // initial creation of a list
        if (!UserInputEventRouter.keyToRespounderDictionary.ContainsKey(key)) {
            UserInputEventRouter.keyToRespounderDictionary[key] = new List<IRespondable>();
        }

        UserInputEventRouter.keyToRespounderDictionary[key].Add(responsable);
    }

    public static void deregisterResponder(string key, IRespondable respondable) {
        if (UserInputEventRouter.keyToRespounderDictionary[key] != null && UserInputEventRouter.keyToRespounderDictionary[key].Contains(respondable)) {
            UserInputEventRouter.keyToRespounderDictionary[key].Remove(respondable);
        }
    }
}