using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : ZennyMonoBehavior
{
    [SerializeField] protected float damage = 4f;

    public virtual void SendDame(Transform obj)
    {
        DameReceiver damageReceiver = obj.GetComponentInChildren<DameReceiver>();
        if (damageReceiver == null) return;
        this.SendDame(damageReceiver);
        this.CreatBulletDisappearFX();
    }
    public virtual void SendDame(DameReceiver dameReceiver)
    {
        dameReceiver.TakeDame(this.damage);
        //this.DestroyObject();
    }
    protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected virtual void CreatBulletDisappearFX()
    {
        string fxName = this.GetBulletDisappearFXName();
        Transform bulletDisappearFX = FXSpawner.Instance.Spawn(fxName, this.transform.position, this.transform.rotation);
        bulletDisappearFX.gameObject.SetActive(true);
    }
    protected virtual string GetBulletDisappearFXName()
    {
        return FXSpawner.bulletDisappearFX;
    }
}
