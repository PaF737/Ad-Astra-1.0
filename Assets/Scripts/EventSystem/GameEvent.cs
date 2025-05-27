using UnityEngine;
using System.Collections.Generic;

public interface IGameEventListener
{
    void InitEvent();
}

[CreateAssetMenu(fileName = "Game Event", menuName = "GameSO/Game Event")]

public class GameEvent : ScriptableObject
{
    private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();

    public void RegisterListener(IGameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void Init()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].InitEvent();
        }
    }
}
