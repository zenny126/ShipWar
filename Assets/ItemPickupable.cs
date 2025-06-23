using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
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
    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
       
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }
    public virtual void Picked()
    {
        this.ItemCtrl.ItemDespawn.DeSpawnObject();
    }
}
