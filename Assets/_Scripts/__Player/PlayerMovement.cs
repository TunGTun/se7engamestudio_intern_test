using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerCtrl _playerCtrl;
    public PlayerCtrl PlayerCtrl => _playerCtrl;

    [SerializeField] float moveSpeed = 200f;
    [SerializeField] float animationSmoothTime = 0.1f;

    Vector3 moveDirection;

    private void Awake()
    {
        if (_playerCtrl == null) _playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    void Update()
    {
        this.ProcessInput();
        this.UpdateAnimation();
    }

    void FixedUpdate()
    {
        this.Move();
        this.RotatePlayer();
    }

    protected virtual void ProcessInput()
    {
        Vector4 input = InputManager.Instance.Direction;
        float horizontal = input.y - input.x;
        float vertical = input.z - input.w;

        moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection.sqrMagnitude > 1) moveDirection.Normalize();
    }

    protected virtual void Move()
    {
        Rigidbody rb = PlayerCtrl.PRigidbody;
        Vector3 targetVelocity = moveDirection * (moveSpeed * Time.fixedDeltaTime);
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);
    }

    protected virtual void RotatePlayer()
    {
        if (moveDirection == Vector3.zero) return;
        PlayerCtrl.transform.rotation = Quaternion.LookRotation(moveDirection);
    }

    protected virtual void UpdateAnimation()
    {
        if (PlayerCtrl.Animator == null) return;

        bool isMoving = moveDirection.sqrMagnitude > 0.01f;

        float targetBlend = isMoving ? 0.6f : 0f;

        PlayerCtrl.Animator.SetFloat("Blend", targetBlend, animationSmoothTime, Time.deltaTime);
    }
}
