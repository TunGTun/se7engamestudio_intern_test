using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"No instance: GameManager.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError($"Duplicate instance: GameManager on {gameObject.name}.", gameObject);
            return;
        }

        _instance = this;

        this.LoadListSoccerBall();
    }

    [SerializeField] CameraController _cameraCtrl;
    public CameraController CameraCtrl => _cameraCtrl;

    [SerializeField] PlayerCtrl _playerCtrl;
    public PlayerCtrl PlayerCtrl => _playerCtrl;

    [SerializeField] List<Transform> _listSoccerGoal = new List<Transform>();
    public List<Transform> ListSoccerGoal => _listSoccerGoal;

    [SerializeField] Transform _soccerBallHolder;

    [SerializeField] List<SoccerBallCtrl> _listSoccerBall = new List<SoccerBallCtrl>();
    public List<SoccerBallCtrl> ListSoccerBall => _listSoccerBall;

    [SerializeField] ParticleSystem _confettiExplosionStars;
    public ParticleSystem ConfettiExplosionStars => _confettiExplosionStars;

    void LoadListSoccerBall()
    {
        _listSoccerBall = _soccerBallHolder.GetComponentsInChildren<SoccerBallCtrl>().ToList();
    }
}
