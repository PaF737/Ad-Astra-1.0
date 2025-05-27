using UnityEngine;

public sealed class BonusHealth : BaseBonus
{
    [SerializeField, Range(100, 1000)]
    private int _health = 100;

    protected override void Activate(Player player)
    {
        if (player.TryGetComponent(out PlayerHealth health))
        {
            health.AddHealth(_health);
        }
    }
}
