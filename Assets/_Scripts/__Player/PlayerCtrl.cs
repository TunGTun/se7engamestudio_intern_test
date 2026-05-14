using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    public Rigidbody PRigidbody => _rigidbody;

    [SerializeField] Animator _animator;
    public Animator Animator => _animator;

    [SerializeField] PlayerKick _playerKick;
    public PlayerKick PlayerKick => _playerKick;

    private void Awake()
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        if (_animator == null) _animator = GetComponentInChildren<Animator>();
        if (_playerKick == null) _playerKick = GetComponent<PlayerKick>();
    }
}
