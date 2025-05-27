using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenePath : MonoBehaviour
{
    [SerializeField] private List<Transform> _pathPoint = new List<Transform>();

    private void Awake()
    {
        Destroy(gameObject);
    }

    public void AddPoint(Transform point)
    {
        _pathPoint.Add(point);
    }

    public List<Vector2> GetPathPoints()
    {
        List<Vector2> points = new List<Vector2>();
        foreach (var item in _pathPoint)
        {
            points.Add(item.position);
        }


        return points;
    }
}
