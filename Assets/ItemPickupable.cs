using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ZennyMonoBehavior
{
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected float itemRadius = 0.2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this._sphereCollider != null) return;
        this._sphereCollider = this.GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = this.itemRadius;
        Debug.LogWarning(transform.name + " LoadSphereCollider", gameObject);
    }
}
