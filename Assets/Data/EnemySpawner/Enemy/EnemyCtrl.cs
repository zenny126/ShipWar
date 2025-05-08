using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ZennyMonoBehavior
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
     public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO { get => enemySO; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyDespawn();
        this.LoadEnemySO();
    }
    protected virtual void LoadEnemyDespawn()
    {
        if (enemyDespawn != null) return;
        this.enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        Debug.Log("LoadEnemyDespawn");
    }
    protected virtual void LoadEnemySO()
    {
        if (enemySO != null) return;
        string resourcePath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resourcePath);
        Debug.Log(transform.name + ": LoadEnemySO" + resourcePath, gameObject);
    }

}
