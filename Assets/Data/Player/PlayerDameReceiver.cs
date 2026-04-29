using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDameReceiver : DameReceiver
{
    [Header("PlayerDameReceiver")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    //[SerializeField] protected PlayerCtrl playerCtrl;
    protected PlayerCtrl PlayerCtrl { get => playerCtrl; }

    public float CurrentHP
    {
        get => this.currentHP;
    }

    public float MaxHP
    {
        get => this.maxHP;
    }

    public void SetCurrentHP(float value)
    {
        this.currentHP = Mathf.Clamp(value, 0f, this.maxHP);
        this.isDead = this.currentHP <= 0f;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log("LoadEnemyCtrl");
    }
    protected override void OnDead()
    {
        //this.OnDeadFX();
        //this.playerCtrl.EnemyDespawn.DeSpawnObject();
    }
    //protected override void ReBorn()
    //{
    //    this.maxHP = this.playerCtrl.EnemySO.maxHp;
    //    base.ReBorn();
    //}
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.enemyDisappearFX;

    }
}
