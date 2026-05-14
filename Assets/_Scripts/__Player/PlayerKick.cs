using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    [SerializeField] string ballLayerName = "SoccerBall";

    [SerializeField] Collider _kickBall = null;
    public Collider KickBall => _kickBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(ballLayerName))
        {
            if (UIManager.Instance.BtnKick.gameObject.activeSelf == false)
                UIManager.Instance.BtnKick.gameObject.SetActive(true);
            _kickBall = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(ballLayerName))
        {
            if (UIManager.Instance.BtnKick.gameObject.activeSelf == true)
                UIManager.Instance.BtnKick.gameObject.SetActive(false);
            if (other == _kickBall)
                _kickBall = null;
        }
    }
}
