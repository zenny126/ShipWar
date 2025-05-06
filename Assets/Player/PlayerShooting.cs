using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootCD = 0.5f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected Transform bulletPrefab;

    private void Update()
    {
        this.IsShooting();
       
    }
    private void FixedUpdate()
    {
        
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if(!this.isShooting) return;
        this.shootTimer += Time.deltaTime;
        if (this.shootTimer< this.shootCD) return;
       this.shootTimer = 0f;
        Vector3 spawnPos = this.transform.position;
        Quaternion spawnRot = this.transform.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPos, spawnRot);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
        //Debug.Log("Shooting");
    }
    protected virtual bool IsShooting()
    {
        this.isShooting= InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
