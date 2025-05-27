using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseBonus : MonoBehaviour
{
    private const float Speed = 5f;

    [SerializeField]
    private UnityEvent Activated;

    [SerializeField, Range(10, 100)] private int _weight = 10;
    public int Weight=> _weight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Activate(player.gameObject);
            Activated.Invoke();
            gameObject.SetActive(false);
        }
    }

    protected virtual void Activate(GameObject player)
    {

    }

    private void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y < -12)
        {
            gameObject.SetActive(false);
        }
    }
}
