using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCheckPoint;
    private const float MoveSpeed = 5f;

    [SerializeField]
    private Path _path;
    private int _index;
    private Rigidbody2D _rb;

    private bool _isMove = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void StartMove()
    {
        _isMove = true;
    }
    
    public void StopMove()
    {
        _isMove = false;
    }

    private void FixedUpdate()
    {
        if(!_isMove)
            return;
        
        _rb.MovePosition(Vector3.MoveTowards(transform.position, _path.Points[_index], MoveSpeed * Time.fixedDeltaTime));
        if (Vector3.Distance(transform.position, _path.Points[_index]) < 0.01f)
        {
            if (_index < _path.Points.Count - 1)
            {
                _index++;
                OnCheckPoint?.Invoke();
            }
            else { Destroy(gameObject); }
        }
    }
}


