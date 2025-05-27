using System.Collections;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    private float _currentTime;
    private bool _isEnabled;

    public bool IsEnabled => _isEnabled;

    public void Activate(float liveTime)
    {
        _currentTime += liveTime;

        if (_isEnabled)
            return;

        ShowShield(true);
        StartCoroutine(Timer());
    }

    private void ShowShield(bool value)
    {
        _isEnabled = value;

        gameObject.SetActive(value);
    }

    private IEnumerator Timer()
    {
        float waitAndStep = 0.5f;
        WaitForSeconds wait = new WaitForSeconds(waitAndStep);
        while (_currentTime > 0)
        {
            _currentTime -= waitAndStep;
            yield return wait;
        }
        
        _currentTime = 0;
        ShowShield(false);
    }
}
