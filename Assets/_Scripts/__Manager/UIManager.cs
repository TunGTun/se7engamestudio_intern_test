using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"No instance: UIManager.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError($"Duplicate instance: UIManager on {gameObject.name}.", gameObject);
            return;
        }

        _instance = this;
    }

    public bool IsFollowBall = false;

    [SerializeField] Transform _btnKick;
    public Transform BtnKick => _btnKick;

    //[SerializeField] Transform _btnAutoKick;
    //[SerializeField] Transform _btnReset;

    private void Start()
    {
        _btnKick.gameObject.SetActive(false);
    }
}
