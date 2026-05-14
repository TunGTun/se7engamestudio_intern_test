using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] public Transform Target;

    [Header("Camera Offset Settings")]
    [SerializeField] protected float height = 12f;

    [Header("Smoothness")]
    [SerializeField] protected float smoothSpeed = 10f;

    void LateUpdate()
    {
        this.FollowTarget();
    }

    protected virtual void FollowTarget()
    {
        Vector3 desiredPosition = new Vector3(Target.position.x, height, Target.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
