using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyEvent {
    Down,
    Pressed
}

public interface IRespondable {
    /// <summary>
    /// Responds to a key event.
    /// </summary>
    /// <returns>Whether this event was properly handled.</returns>
    /// 
    bool respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent);
}

public class UserInputEventRouter : MonoBehaviour {
    private static Dictionary<KeyCode, Dictionary<KeyEvent, List<IRespondable>>> keyToRespounderDictionary = new Dictionary<KeyCode, Dictionary<KeyEvent, List<IRespondable>>>();

    void Update() {
        foreach (KeyValuePair<KeyCode, Dictionary<KeyEvent, List<IRespondable>>> keyCodeElement in UserInputEventRouter.keyToRespounderDictionary) {
            foreach (KeyValuePair<KeyEvent, List<IRespondable>> keyEventElement in UserInputEventRouter.keyToRespounderDictionary[keyCodeElement.Key]) {
                switch (keyEventElement.Key) {
                    case KeyEvent.Down:
                        if (Input.GetKeyDown(keyCodeElement.Key)) {
                            for (int i = keyEventElement.Value.Count - 1; i >= 0; i--) { // backwards to ensure the last to register gets the first chance to respond
                                if (keyEventElement.Value[i].respoundToKeyCodeEvent(keyCodeElement.Key, keyEventElement.Key)) {
                                    return;
                                }
                            }
                        }
                        break;
                    case KeyEvent.Pressed:
                        if (Input.GetKey(keyCodeElement.Key)) {
                            for (int i = keyEventElement.Value.Count - 1; i >= 0; i--) { // backwards to ensure the last to register gets the first chance to respond
                                if (keyEventElement.Value[i].respoundToKeyCodeEvent(keyCodeElement.Key, keyEventElement.Key)) {
                                    return;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }

    public static void registerResponder(KeyCode keyCode, KeyEvent keyEvent, IRespondable respondable) {
        // if this is the first responder to register this key
        if (!UserInputEventRouter.keyToRespounderDictionary.ContainsKey(keyCode)) {
            UserInputEventRouter.keyToRespounderDictionary[keyCode] = new Dictionary<KeyEvent, List<IRespondable>>();

            // if this is the first responder to register this key event
            if (!UserInputEventRouter.keyToRespounderDictionary[keyCode].ContainsKey(keyEvent)) {
                UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent] = new List<IRespondable>();
            }
        }

        UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent].Add(respondable);
    }

    public static void deregisterResponder(KeyCode keyCode, KeyEvent keyEvent, IRespondable respondable) {
        // if we've seen this keyCode registered before
        if (UserInputEventRouter.keyToRespounderDictionary[keyCode] != null) {
            // if we've seen this keyEvent registered before
            if (UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent] != null) {
                // if we've seen this respondable before
                if (UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent].Contains(respondable)) {
                    UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent].Remove(respondable);

                }
            }
        }
    }
}