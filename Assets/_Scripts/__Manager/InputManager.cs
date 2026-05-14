using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"No instance: InputManager.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError($"Duplicate instance: InputManager on {gameObject.name}.", gameObject);
            return;
        }

        _instance = this;
    }

    [SerializeField] bool _canControl = true;
    public bool CanControl
    {
        get => _canControl;
        set
        {
            if (_canControl == value) return;
            _canControl = value;
            ResetInputState();
        }
    }

    [SerializeField] protected Vector4 _direction;
    public Vector4 Direction => _direction;

    [SerializeField] protected bool _kickInput;
    public bool KickInput => _kickInput;

    [SerializeField] protected bool _autoKickInput;
    public bool AutoKickInput => _autoKickInput;

    [SerializeField] protected bool _resetInput;
    public bool ResetInput => _resetInput;

    void Update()
    {
        if (!CanControl) return;

        this.GetDirectionByKeyDown();
        this.CheckKickInput();
        this.CheckAutoKickInput();
        this.CheckResetInput();
    }

    public void ResetInputState()
    {
        this._direction = Vector4.zero;
        this._kickInput = false;
        this._autoKickInput = false;
        this._resetInput = false;
    }

    protected virtual void GetDirectionByKeyDown()
    {
        this._direction.x = Input.GetKey(KeyCode.A) ? 1 : 0;
        this._direction.y = Input.GetKey(KeyCode.D) ? 1 : 0;
        this._direction.z = Input.GetKey(KeyCode.W) ? 1 : 0;
        this._direction.w = Input.GetKey(KeyCode.S) ? 1 : 0;
    }

    protected virtual void CheckKickInput()
    {
        this._kickInput = Input.GetKeyDown(KeyCode.K);
    }

    protected virtual void CheckAutoKickInput()
    {
        this._autoKickInput = Input.GetKeyDown(KeyCode.I);
    }

    protected virtual void CheckResetInput()
    {
        this._resetInput = Input.GetKeyDown(KeyCode.R);
    }
}