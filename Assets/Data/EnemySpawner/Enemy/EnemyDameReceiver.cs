using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceiver : DameReceiver
{
    [Header("EnemyDameReceiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected EnemyCtrl EnemyCtrl { get => enemyCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        this.enemyCtrl =transform.parent.GetComponent<EnemyCtrl>();
       Debug.Log("LoadEnemyCtrl");
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.enemyCtrl.EnemyDespawn.DeSpawnObject();
    }
    protected override void ReBorn()
    {
        this.maxHP = this.enemyCtrl.EnemySO.maxHp;
        base.ReBorn();
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.enemyDisappearFX;
        
    }
}
