using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBtnKick : BaseButton
{
    protected override void OnClick()
    {
        if (UIManager.Instance.IsFollowBall) return;

        SoccerBallCtrl soccerBallCtrl = this.GetBall();
        if (soccerBallCtrl == null ) return;

        GameManager.Instance.CameraCtrl.Target = soccerBallCtrl.transform;
        UIManager.Instance.IsFollowBall = true;
        InputManager.Instance.CanControl = false;

        soccerBallCtrl.OnKick();

        GameManager.Instance.ListSoccerBall.Remove(soccerBallCtrl);
    }

    protected abstract SoccerBallCtrl GetBall();
}
