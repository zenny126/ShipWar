using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class DameReceiver : ZennyMonoBehavior
{
    [SerializeField] protected float currentHP = 10f;
    [SerializeField] protected float maxHP = 10f;
    [SerializeField] protected SphereCollider sphereCollider;
    protected override void Start()
    {
        base.Start();
        this.ReBorn();
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void ReBorn()
    {
        this.currentHP = this.maxHP;
    }
    protected virtual void Heal(float heal)
    {
        this.currentHP += heal;
        if (this.currentHP > this.maxHP)
        {
            this.currentHP = this.maxHP;
        }
    }
    protected virtual bool IsDead()
    {
        if (this.currentHP <= 0)
        {
            return true;
        }
        return false;
    }
    public virtual void TakeDame(float dame)
    {
        this.currentHP -= dame;
        if (this.currentHP < 0)
        {
            this.currentHP = 0;
        }
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.4f;
        Debug.Log("LoadSphereCollider");
    }
}
