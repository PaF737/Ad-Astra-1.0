using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool IsActive => gameObject.activeSelf;
    
    public void Activate()
    {
        gameObject.SetActive(true);
    }
    
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
