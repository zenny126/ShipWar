using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : ZennyMonoBehavior
{
    [SerializeField] List<Transform> spawnPoints;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count>0) return;
        
        foreach (Transform child in this.transform)
        {
            spawnPoints.Add(child);
        }
        Debug.Log("Load SpawnPoints");
    }
    public virtual Transform GetRandom()
    {
        int ran= Random.Range(0, spawnPoints.Count);
        return this.spawnPoints[ran];
    }
}
