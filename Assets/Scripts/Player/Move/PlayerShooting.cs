using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField, Range(0.1f, 1f)] private float _shootingInterval = 0.5f;
    [SerializeField] private CannonBase[] _cannons;
    
    private IEnumerator _timer;
    
    public void ActivateShooting()
    {
        DeactivateShooting();
        
        _timer = Timer();
        StartCoroutine(_timer);
    }
    
    public void DeactivateShooting()
    {
        if (_timer != null)
        {
            StopCoroutine(_timer);
            _timer = null;
        }
    }
    
    private IEnumerator Timer()
    {
        var wait = new WaitForSeconds(_shootingInterval);

        while (true)
        {
            Shot();
            yield return wait;
        }
    }
    
    public void Shot()
    {
        foreach (var cannon in _cannons)
        {
            cannon.Shot();
        }
    }
}
