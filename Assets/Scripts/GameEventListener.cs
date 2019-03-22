using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
    [SerializeField]
    [Tooltip("Which game event to listen for.")]
    private GameEvent gameEvent;
    [SerializeField]
    [Tooltip("Which game event to fire off when we hear what we're listening for.")]
    private UnityEvent response;

    private void OnEnable()  {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable() {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised() {
        response.Invoke();
    }
}