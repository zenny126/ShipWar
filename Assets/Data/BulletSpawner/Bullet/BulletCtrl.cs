using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ZennyMonoBehavior
{
    [SerializeField] protected DameSender dameSender;
    public DameSender DamageSender => dameSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameSender();
        this.LoadBulletDespawn();
       // this.loadShooter();
    }

    //protected virtual void loadShooter()
    //{
    //    //
    //    if (shooter != null) return;
    //    this.shooter = FindAnyObjectByType<PlayerCtrl>().transform;
    //}
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
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
