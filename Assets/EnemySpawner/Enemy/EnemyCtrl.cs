using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ZennyMonoBehavior
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
     public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
    }
    protected virtual void LoadEnemyDespawn()
    {
        if (enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log("LoadEnemyDespawn");
    }

}
