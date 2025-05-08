using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : ZennyMonoBehavior
{
    
    
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    [SerializeField] protected int currentObjectCount = 0;
    public int CurrentObjectCount
    {
        get { return this.currentObjectCount; }
    }

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder= transform.Find("Holder");
    }
    protected void LoadPrefabs()
    {   
        if(this.prefabs.Count>0) return;


        Transform prefabObj= transform.Find("Prefabs");
      
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string prefabName,Vector3 spawnPos,Quaternion spawnRot)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogError("Prefab not found");
            return null;
        }
        //Transform newPrefab= this.GetObjectFromPool(prefab);
        // newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        //newPrefab.parent=this.holder;
        //this.currentObjectCount++;
        //return newPrefab;
        return this.Spawn(prefab, spawnPos, spawnRot);
    }public virtual Transform Spawn(Transform prefab,Vector3 spawnPos,Quaternion spawnRot)
    {
        
        Transform newPrefab= this.GetObjectFromPool(prefab);
         newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        newPrefab.parent=this.holder;
        this.currentObjectCount++;
        return newPrefab;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform obj in this.poolObjs)
        {
            if (obj.name == prefab.name)
            {
                this.poolObjs.Remove(obj);
  
                return obj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void DeSpawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.currentObjectCount--;
    }
    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }
        //Debug.LogError("Prefab not found");
        return null;
    }
   public virtual Transform GetRandomPrefab()
    {
        int randomIndex = Random.Range(0, this.prefabs.Count);
        return this.prefabs[randomIndex];
    }
}
