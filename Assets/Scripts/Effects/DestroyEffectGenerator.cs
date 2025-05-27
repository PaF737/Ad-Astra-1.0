using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DestroyEffectGenerator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _prefab;

    private List<GameObject> _effects = new List<GameObject>();
    private const int DefaultCount = 3;

    private void Awake()
    {
        for (int i = 0; i < DefaultCount; i++)
        {
            Create();
        }
    }

    private GameObject Create()
    {
        GameObject effect = Instantiate(_prefab.gameObject, transform);
        _effects.Add(effect);
        return effect;
    }

    public GameObject GetFreeEffect()
    {
        foreach (var item in _effects)
        {
            if (item.activeInHierarchy == false)            
                return item;
            
        }

        return Create();
    }
}
