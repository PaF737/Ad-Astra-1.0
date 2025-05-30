using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Game Event", menuName = "GameSO/Game Event")]

public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

    public void RegisterListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
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
