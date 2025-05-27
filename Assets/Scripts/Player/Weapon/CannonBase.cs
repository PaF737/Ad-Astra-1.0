using System.Collections;
using UnityEngine;

public abstract class CannonBase : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    protected void BulletActivate(Transform bulletStartPosition)
    {
        var bullet = BulletsPool.Instance.GetBullet(_bulletPrefab);
        bullet.transform.position = bulletStartPosition.position;
        bullet.transform.Rotate(transform.rotation.eulerAngles);
        bullet.Activate();
    }

    public abstract void Shot();
}
