using UnityEngine;

public class BonusShield : BaseBonus
{
    [SerializeField]
    private float _liveTime = 2f;

    protected override void Activate(Player player)
    {
        player.ActivateShield(_liveTime);
    }
}
