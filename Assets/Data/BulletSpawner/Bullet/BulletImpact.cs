using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("BulletImpact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log("LoadSphereCollider");
    }
    protected virtual void LoadRigidbody()
    {
        if (_rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log("LoadRigidbody");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletCtrl.Shooter) return;
        this.bulletCtrl.DamageSender.SendDame(other.transform);
        this.CreatBulletDisappearFX();

    }
    protected virtual void CreatBulletDisappearFX()
    {
        string fxName = this.GetBulletDisappearFXName();
        Transform bulletDisappearFX= FXSpawner.Instance.Spawn(fxName, this.transform.position, this.transform.rotation);
        bulletDisappearFX.gameObject.SetActive(true);
    }
    protected virtual string GetBulletDisappearFXName()
    {
        return FXSpawner.bulletDisappearFX;
    }
}
