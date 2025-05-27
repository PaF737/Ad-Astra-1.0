using UnityEngine;
using System;

public class DestroyEffect : MonoBehaviour
{
    public static event Action<Transform> OnEffectActivated;

    public void Activate()
    {
        OnEffectActivated?.Invoke(transform);
    }
}
