using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  DeSpawn : ZennyMonoBehavior
{
   

    private void FixedUpdate()
    {
        this.DeSpawning();
    }
   
   

    protected virtual void DeSpawning()
    {
        if (!this.CanDeSpawn()) return;
        this.DeSpawnObject();
    }
    protected abstract bool CanDeSpawn();
    public virtual void DeSpawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

}
