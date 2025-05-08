using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : ZennyMonoBehavior
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }
    [SerializeField] protected EnemySpawnPoints enemySpawnPoints;
    public EnemySpawnPoints SpawnPoint { get => enemySpawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (enemySpawner != null) return;

        enemySpawner = this.GetComponent<EnemySpawner>();
        Debug.Log("Load EnemyCtrl");
    }
    protected virtual void LoadSpawnPoint()
    {
        if (enemySpawnPoints != null) return;
        enemySpawnPoints = this.GetComponentInChildren<EnemySpawnPoints>();
        Debug.Log("Load SpawnPoint");
    }
}
