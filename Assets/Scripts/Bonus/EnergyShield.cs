using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D _collider2D;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private float _currentTime;
    private Transform _target;
    private bool _isEnabled;

    public bool IsEnabled => _isEnabled;

    public void Activate(float liveTime, Transform target)
    {
        _currentTime += liveTime;

        if (_isEnabled == false)
        {
            _target = target;
            transform.position = target.position;            
            ShowShield(true);
            StartCoroutine(Timer());
        }
    }

    private void Update()
    {
        if (_isEnabled)
        {
            transform.position = _target.position + new Vector3(0, -0.3f, 0);
        }
    }

    private void ShowShield(bool value)
    {
        _collider2D.enabled = value;
        _animator.enabled = value;
        _spriteRenderer.enabled = value;
        _isEnabled = value;
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
        transform.SetParent(null);
    }
}
