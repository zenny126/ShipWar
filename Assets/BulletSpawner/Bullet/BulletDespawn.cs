using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DeSpawnByDistance
{
    public override void DeSpawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
