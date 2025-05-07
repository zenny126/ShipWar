using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDameSender : DameSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log("LoadBulletCtrl");
    }
    public override void SendDame(DameReceiver dameReceiver)
    {
        base.SendDame(dameReceiver);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DeSpawnObject();
    }
}
