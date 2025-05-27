using UnityEngine;
using System.Collections.Generic;

public class BulletsPool : MonoBehaviour
{
    private readonly Dictionary<string, List<Bullet>> _bullets = new Dictionary<string, List<Bullet>>();

    public static BulletsPool Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Bullet GetBullet(Bullet bulletPrefab)
    {
        if (_bullets.ContainsKey(bulletPrefab.name))
        {
            foreach (var bullet in _bullets[bulletPrefab.name])
            {
                if (!bullet.IsActive)
                    return bullet;
            }
            return Create(bulletPrefab);
        }
        else
        {
            _bullets.Add(bulletPrefab.name, new List<Bullet>());
            return Create(bulletPrefab);
        }
    }

    private Bullet Create(Bullet bulletPrefab)
    {
        var bullet = Instantiate(bulletPrefab, transform);
        bullet.Deactivate();
        _bullets[bulletPrefab.name].Add(bullet);
        return bullet;
    }
}
