using UnityEngine;

public class EnemyBonusDrop : MonoBehaviour
{
    private bool _haveBonus;
    private BonusQueue _bonusQueue;

    public void SetBonusQueue(BonusQueue bonusQueue)
    {
        _bonusQueue = bonusQueue;
    }

    public void SetHaveBonus(bool value)
    {
        _haveBonus = value;
    }

    public void Activate()
    {
        if (_haveBonus)
        {
            _bonusQueue.Activate(transform.position);
        }
    }
}
