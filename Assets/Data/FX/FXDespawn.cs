using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    public override void DeSpawnObject()
    {
        FXSpawner.Instance.DeSpawn(transform.parent);
    }
}
