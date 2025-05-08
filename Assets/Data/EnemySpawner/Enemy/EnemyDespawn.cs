using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DeSpawnByDistance
{
    public override void DeSpawnObject()
    {
        EnemySpawner.Instance.DeSpawn(transform.parent);
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 20f;
    }
}
