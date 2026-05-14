using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBallCtrl : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float ballRadius = 0.5f;

    bool isMoving = false;
    Vector3 targetPosition;
    Vector3 moveDirection;

    void Update()
    {
        this.MoveAndRoll();
    }

    public void OnKick()
    {
        List<Transform> goals = GameManager.Instance.ListSoccerGoal;

        Transform nearestGoal = null;
        float minDistance = Mathf.Infinity;
        foreach (Transform goal in goals)
        {
            float dist = (goal.position - transform.position).sqrMagnitude;
            if (dist < minDistance)
            {
                minDistance = dist;
                nearestGoal = goal;
            }
        }

        targetPosition = nearestGoal.position;
        targetPosition.y = transform.position.y;
        moveDirection = (targetPosition - transform.position).normalized;
        isMoving = true;
    }

    void MoveAndRoll()
    {
        if (!isMoving) return;

        float distanceThisFrame = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, distanceThisFrame);

        Vector3 rotationAxis = Vector3.Cross(Vector3.up, moveDirection);
        float rotationAngle = (distanceThisFrame / ballRadius) * Mathf.Rad2Deg;
        transform.Rotate(rotationAxis, rotationAngle, Space.World);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f) this.Goal();
    }

    void Goal()
    {
        isMoving = false;
        StartCoroutine(this.WaitAtGoal());
        GameManager.Instance.ConfettiExplosionStars.Play();
    }

    private IEnumerator WaitAtGoal()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.CameraCtrl.Target = GameManager.Instance.PlayerCtrl.transform;
        UIManager.Instance.IsFollowBall = false;
        InputManager.Instance.CanControl = true;

        this.gameObject.SetActive(false);
    }
}
