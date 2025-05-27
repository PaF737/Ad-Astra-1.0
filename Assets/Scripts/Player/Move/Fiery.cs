using UnityEngine;

public class Fiery : MonoBehaviour
{
    [SerializeField] private PlayerMove controller;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("MoveX", controller.Movement.x);
        _animator.SetFloat("MoveY", controller.Movement.y);
    }

}
