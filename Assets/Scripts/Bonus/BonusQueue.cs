using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusQueue : MonoBehaviour
{
    private readonly Queue<GameObject> _bonuses = new Queue<GameObject>();

    private GameObject _tempObject;

    public void AddObject(GameObject bonus)
    {
        _bonuses.Enqueue(bonus);
    }

    public void Activate(Vector3 position)
    {
        if (_bonuses.Count > 0)
        {
            _tempObject = _bonuses.Dequeue();
            _tempObject.transform.position = position;
            _tempObject.SetActive(true);
        }
    }
}
