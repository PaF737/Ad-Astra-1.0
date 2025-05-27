using UnityEngine;

public class EnemyDestraction : MonoBehaviour
{
    public void Activate()
    {
        Destroy(gameObject, 0.2f);       
    }
}
