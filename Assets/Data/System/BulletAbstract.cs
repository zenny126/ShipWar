using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : ZennyMonoBehavior
{
    [Header("BulletAbs")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl
    {
        get { return bulletCtrl; }

        
         
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameReceiver();
    }
    protected virtual void LoadDameReceiver()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log("LoadDameReceiver");
    }
}
