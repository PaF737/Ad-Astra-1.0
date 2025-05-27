using System;
using UnityEngine;


[RequireComponent(typeof(DestroyEffectGenerator))]
public class DestroyEffectSpawner : MonoBehaviour
{
    private DestroyEffectGenerator _generator;

    private void Awake()
    {
        _generator = GetComponent<DestroyEffectGenerator>();
    }


    private void OnDisable()
    {
        DestroyEffect.OnEffectActivated -= DestroyEffect_OnEffectActivated;
    }

    private void OnEnable()
    {
        DestroyEffect.OnEffectActivated += DestroyEffect_OnEffectActivated;
    }

    private void DestroyEffect_OnEffectActivated(Transform obj)
    {
        GameObject effect = _generator.GetFreeEffect();
        effect.transform.position = obj.position;
        effect.SetActive(true);
    }
}
