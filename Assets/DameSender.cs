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

}
