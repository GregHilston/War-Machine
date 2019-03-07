using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyEvent {
    Down,
    Pressed
}

public interface IKeyCodeEventRespondable {
    /// <summary>
    /// Respounds to a key event.
    /// </summary>
    /// <returns><c>true</c>, if to key code event was respounded, <c>false</c> otherwise.</returns>
    /// <param name="keyCode">Key code.</param>
    /// <param name="keyEvent">Key event.</param>
    bool respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent);
}

public interface IMouseEventRespondable {
    /// <summary>
    /// Respounds to mouse event.
    /// </summary>
    /// <returns><c>true</c>, if to mouse event was respounded, <c>false</c> otherwise.</returns>
    /// <param name="mouseAxis">Mouse axis.</param>
    /// <param name="delta">Delta.</param>
    bool respoundToMouseEvent(string mouseAxis, float delta);
}

public class UserInputEventRouter : MonoBehaviour {
    private static Dictionary<KeyCode, Dictionary<KeyEvent, List<IKeyCodeEventRespondable>>> keyToRespounderDictionary = new Dictionary<KeyCode, Dictionary<KeyEvent, List<IKeyCodeEventRespondable>>>();
    private static Dictionary<string, List<IMouseEventRespondable>> axisToRespounderDictionary = new Dictionary<string, List<IMouseEventRespondable>>();

    void CheckAllRegisteredKeyCodes() {
        foreach (KeyValuePair<KeyCode, Dictionary<KeyEvent, List<IKeyCodeEventRespondable>>> keyCodeElement in UserInputEventRouter.keyToRespounderDictionary) {
            foreach (KeyValuePair<KeyEvent, List<IKeyCodeEventRespondable>> keyEventElement in UserInputEventRouter.keyToRespounderDictionary[keyCodeElement.Key]) {
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

    void CheckAllRegisteredMouseAxises() {
        foreach (KeyValuePair<string, List<IMouseEventRespondable>> mouseAxisElement in UserInputEventRouter.axisToRespounderDictionary) {
            for (int i = mouseAxisElement.Value.Count - 1; i >= 0; i--) { // backwards to ensure the last to register gets the first chance to respond
                if(mouseAxisElement.Value[i].respoundToMouseEvent(mouseAxisElement.Key, Input.GetAxis(mouseAxisElement.Key))) {
                    return;
                }
            }
        }
    }

    void Update() {
        this.CheckAllRegisteredKeyCodes();
        this.CheckAllRegisteredMouseAxises();
    }

    public static void registerKeyboardResponder(KeyCode keyCode, KeyEvent keyEvent, IKeyCodeEventRespondable respondable) {
        // if this is the first responder to register this key
        if (!UserInputEventRouter.keyToRespounderDictionary.ContainsKey(keyCode)) {
            UserInputEventRouter.keyToRespounderDictionary[keyCode] = new Dictionary<KeyEvent, List<IKeyCodeEventRespondable>>();

            // if this is the first responder to register this key event
            if (!UserInputEventRouter.keyToRespounderDictionary[keyCode].ContainsKey(keyEvent)) {
                UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent] = new List<IKeyCodeEventRespondable>();
            }
        }

        UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent].Add(respondable);
    }

    public static void deregisterKeyboardResponder(KeyCode keyCode, KeyEvent keyEvent, IKeyCodeEventRespondable keyCodeEventRespondable) {
        // if we've seen this keyCode registered before
        if (UserInputEventRouter.keyToRespounderDictionary[keyCode] != null) {
            // if we've seen this keyEvent registered before
            if (UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent] != null) {
                // if we've seen this respondable before
                if (UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent].Contains(keyCodeEventRespondable)) {
                    UserInputEventRouter.keyToRespounderDictionary[keyCode][keyEvent].Remove(keyCodeEventRespondable);

                }
            }
        }
    }

    public static void registerMouseResponder(string mouseAxis, IMouseEventRespondable mouseEventRespondable) {
        // if this is the first responder to register this key
        if (!UserInputEventRouter.axisToRespounderDictionary.ContainsKey(mouseAxis)) {
            UserInputEventRouter.axisToRespounderDictionary[mouseAxis] = new List<IMouseEventRespondable>();
        }

        UserInputEventRouter.axisToRespounderDictionary[mouseAxis].Add(mouseEventRespondable);
    }

    public static void deregisterMouseResponder(string mouseAxis, IMouseEventRespondable mouseEventRespondable) {
        // if we've seen this mouseAxis registered before
        if (UserInputEventRouter.axisToRespounderDictionary[mouseAxis] != null) {
            // if we've seen this respondable before
            if (UserInputEventRouter.axisToRespounderDictionary[mouseAxis].Contains(mouseEventRespondable)) {
                UserInputEventRouter.axisToRespounderDictionary[mouseAxis].Remove(mouseEventRespondable);
            }
        }
    }
}