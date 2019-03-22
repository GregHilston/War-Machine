using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
public class GameEvent : ScriptableObject  {
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise() {
        // reverse order to make sure the last one added gets to be alerted first
        for (int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener) {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) {
        listeners.Remove(listener);
    }
}