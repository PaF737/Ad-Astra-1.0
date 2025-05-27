using UnityEngine;

public class CannonSingle :CannonBase
{
    [SerializeField] private Transform _bulletStartPosition;

    public override void Shot()
    {
       BulletActivate(_bulletStartPosition);
    }
}
