using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : ZennyMonoBehavior
{
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomCountLimit = 10;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnerCtrl();
    }
    protected override void Start()
    {
        // base.Start();
        // this.EnemySpawning();
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
        if (this.RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        randomTimer = 0f;


        Transform prefab = this.enemySpawnerCtrl.EnemySpawner.GetRandomPrefab();


        Vector3 spawnPos = this.enemySpawnerCtrl.SpawnPoint.GetRandom().position;
        Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
        
        

        Transform obj = this.enemySpawnerCtrl.EnemySpawner.Spawn(prefab, spawnPos, spawnRot);
        obj.gameObject.SetActive(true);
        //Invoke(nameof(this.EnemySpawning),1f);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentEnemyCount = this.enemySpawnerCtrl.EnemySpawner.CurrentObjectCount;
        return currentEnemyCount >= this.randomCountLimit;
    }
}
