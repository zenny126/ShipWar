using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : ZennyMonoBehavior
{
    [SerializeField] protected ItemDeSpawn itemDespawn;
    public ItemDeSpawn ItemDespawn { get => itemDespawn; }

    //[SerializeField] protected EnemySO enemySO;
    //public EnemySO EnemySO { get => enemySO; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
      //  this.LoadEnemySO();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDeSpawn>();
        Debug.Log("LoadItemDespawn");
    }
    //protected virtual void LoadEnemySO()
    //{
    //    if (enemySO != null) return;
    //    string resourcePath = "Enemy/" + transform.name;
    //    this.enemySO = Resources.Load<EnemySO>(resourcePath);
    //    Debug.Log(transform.name + ": LoadEnemySO" + resourcePath, gameObject);
    //}

}
