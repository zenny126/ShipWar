using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ZennyMonoBehavior
{
    [SerializeField] protected DameSender dameSender;
    public DameSender DamageSender
    {
        get { return dameSender; }
    }
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn
    {
        get { return bulletDespawn; }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameSender();
        this.LoadBulletDespawn();
    }
    protected virtual void LoadDameSender()
    {
        if (dameSender != null) return;
        this.dameSender = GetComponentInChildren<DameSender>();
        Debug.Log("LoadDameSender");
    }
    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log("LoadBulletDespawn");
    }
}
