using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;
    
    public void Activate()
    {
        gameObject.SetActive(true);
        _enemyMove.StartMove();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        _enemyMove.StopMove();
    }
}


