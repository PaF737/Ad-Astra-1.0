using UnityEngine;

public class EnemyBonusDrop : MonoBehaviour
{
    private BaseBonus _bonus;

    public void SetBonus(BaseBonus bonus)
    {
        _bonus = bonus;
    }

    public void Activate()
    {
        if (_bonus != null)
        {
            _bonus.gameObject.SetActive(true);
            _bonus.transform.position = transform.position;
        }
    }
}
