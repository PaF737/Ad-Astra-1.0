using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerHealth : ObjectHealth
{
    [SerializeField]
    private UnityEvent<int> OnChangedHealth;

    protected override void OnEnable()
    {
        base.OnEnable();
        OnChangedHealth.Invoke(GetCurrentHealth());
    }

    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        OnChangedHealth.Invoke(GetCurrentHealth());
    }

    public void PrintHealt()
    {
        Debug.Log(GetCurrentHealth());
    }
}
