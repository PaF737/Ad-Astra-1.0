using UnityEngine;

public class BonusShield : BaseBonus
{
    [SerializeField]
    private EnergyShield _shieldPrefab;

    [SerializeField]
    private float _liveTime = 2f;


    private static EnergyShield _currentShield;

    private void CheckShield()
    {
        if (_currentShield == null)
        {
            _currentShield = Instantiate(_shieldPrefab);
        }
    }

    protected override void Activate(GameObject player)
    {
        CheckShield();
        _currentShield.Activate(_liveTime, player.transform);
    }
}
