using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ShotTimer : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1f)]
    private float _shothInterval = 0.5f;

    [SerializeField]
    private UnityEvent OnShot;

    private WaitForSeconds _wait;

    private IEnumerator Timer()
    {
        while (true)
        {
            OnShot.Invoke();
            yield return _wait;
        }
    }

    public void StartTime()
    {
        _wait = new WaitForSeconds(_shothInterval);
        StartCoroutine(Timer());
    }
}
