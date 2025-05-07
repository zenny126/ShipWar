using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : ZennyMonoBehavior
{
    protected static GameCtrl instance;
    public static GameCtrl Instance
    {
        get => instance;
    }
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera
    {
        get => this.mainCamera;
    }

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance!= null) Debug.LogError("GameCtrl instance already exists");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera == null)
        {
            this.mainCamera = Camera.main;
        }
    }
}
