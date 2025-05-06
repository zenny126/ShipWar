using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : ZennyMonoBehavior
{
    [SerializeField]  protected EnemySpawnerCtrl enemySpawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnerCtrl();
    }
    protected virtual void FixedUpdate()
    {
        this.EnemySpawning();
    }
    protected virtual void LoadEnemySpawnerCtrl()
    {
        if (enemySpawnerCtrl != null) return;
        
            enemySpawnerCtrl = this.GetComponent<EnemySpawnerCtrl>();
        Debug.Log("Load EnemyCtrl");
    }
    protected virtual void EnemySpawning()
    {
        Vector3 spawnPos = this.enemySpawnerCtrl.SpawnPoint.GetRandom().position;
        Quaternion spawnRot = Quaternion.Euler(0, 0, Random.Range(225f, 315f));
        Transform obj= this.enemySpawnerCtrl.EnemySpawner.Spawn(EnemySpawner.EnemyOne,spawnPos,spawnRot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.EnemySpawning), 100f);
    }

}
