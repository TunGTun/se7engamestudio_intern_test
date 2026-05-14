using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button _button;

    private void Awake()
    {
        if (this._button == null) this._button = GetComponent<Button>();
    }

    private void Start()
    {
        this.AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {
        this._button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
}
