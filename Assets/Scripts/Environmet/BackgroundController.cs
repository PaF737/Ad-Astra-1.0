using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _speed = 1f;

    private float _positionMinY;
    private Vector2 _restartPosition;

    private void Awake()
    {       
        _restartPosition = transform.position;
        _positionMinY = _sprite.bounds.size.y * 2 - _restartPosition.y;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -_positionMinY)
        {
            transform.position = _restartPosition;
        }
    }
}

