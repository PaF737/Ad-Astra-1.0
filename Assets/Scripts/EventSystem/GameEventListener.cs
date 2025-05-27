using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private UnityEvent _action;

    private void OnEnable()
    {
        _gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        _gameEvent.UnregisterListener(this);
    }

    public void InitEvent()
    {
        _action.Invoke();
    }

}
