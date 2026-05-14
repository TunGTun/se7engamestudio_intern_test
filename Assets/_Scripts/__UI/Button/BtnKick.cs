using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnKick : BaseBtnKick
{
    protected override SoccerBallCtrl GetBall()
    {
        Collider kickBallCol = GameManager.Instance.PlayerCtrl.PlayerKick.KickBall;
        return kickBallCol.GetComponent<SoccerBallCtrl>();
    }

    private void Update()
    {
        if (InputManager.Instance.KickInput) this.OnClick();
    }
}
