using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BtnAutoKick : BaseBtnKick
{
    protected override SoccerBallCtrl GetBall()
    {
        return this.FindFurthestBall();
    }

    private SoccerBallCtrl FindFurthestBall()
    {
        PlayerCtrl player = GameManager.Instance.PlayerCtrl;
        List<SoccerBallCtrl> balls = GameManager.Instance.ListSoccerBall;

        Vector3 playerPos = player.transform.position;

        SoccerBallCtrl furthestBall = null;
        float maxDistanceSqr = -1f;

        foreach (SoccerBallCtrl ball in balls)
        {
            float distanceSqr = Vector3.SqrMagnitude(ball.transform.position - playerPos);

            if (distanceSqr > maxDistanceSqr)
            {
                maxDistanceSqr = distanceSqr;
                furthestBall = ball;
            }
        }

        return furthestBall;
    }

    private void Update()
    {
        if (InputManager.Instance.AutoKickInput) this.OnClick();
    }
}
