using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField, Range(100, 500)]
    private int _damage = 150;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
        ResetObject();
    }

    private void ResetObject()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}
