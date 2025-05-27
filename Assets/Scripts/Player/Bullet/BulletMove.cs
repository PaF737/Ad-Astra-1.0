using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;

    [SerializeField] private Rigidbody2D _rb;

    private void FixedUpdate()
    {
        _rb.linearVelocity = transform.up * _speed;

    }
}
