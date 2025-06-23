using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : ZennyMonoBehavior
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected float lootDistance = 0.5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadRigidbody();
        this.LoadSphereCollider();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory!=null) return;
        this.inventory = this.transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + " LoadInventory",gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = this.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        this._rigidbody.useGravity = false;
        Debug.LogWarning(transform.name + " LoadRigidbody", gameObject);
    }
    protected virtual void LoadSphereCollider()
    {
        if (this._sphereCollider != null) return;
        this._sphereCollider = this.GetComponent<SphereCollider>();
        this._sphereCollider.isTrigger = true;
        this._sphereCollider.radius = this.lootDistance;
        Debug.LogWarning(transform.name + " LoadSphereCollider", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        
        ItemPickupable itemPickupable = other.transform.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        //Debug.Log(other.name);
        //Debug.Log(other.transform.parent.name);
        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.inventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
