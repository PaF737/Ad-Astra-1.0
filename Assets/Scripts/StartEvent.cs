using UnityEngine;

public class StartEvent : MonoBehaviour
{
    [SerializeField] private GameEvent _sceneStart;
    [SerializeField] private GameEvent _gameplay;


    private void Start()
    {
        _sceneStart.Init();
        _gameplay.Init();
    }
}
