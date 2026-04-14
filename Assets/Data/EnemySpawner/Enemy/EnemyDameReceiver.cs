//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyDameReceiver : DameReceiver
//{
//    [Header("EnemyDameReceiver")]
//    [SerializeField] protected EnemyCtrl enemyCtrl;
//    [SerializeField] protected EnemyCtrl EnemyCtrl { get => enemyCtrl; }

//    protected override void LoadComponents()
//    {
//        base.LoadComponents();
//        this.LoadEnemyCtrl();
//    }
//    protected virtual void LoadEnemyCtrl()
//    {
//        if (enemyCtrl != null) return;
//        this.enemyCtrl =transform.parent.GetComponent<EnemyCtrl>();
//       Debug.Log("LoadEnemyCtrl");
//    }
//    protected override void ReBorn()
//    {
//        this.maxHP = this.enemyCtrl.EnemySO.maxHp;
//        base.ReBorn();
//    }
//    protected override void OnDead()
//    {
//        this.OnDeadFX();
//        this.enemyCtrl.EnemyDespawn.DeSpawnObject();
//        //Drop here
//        this.OnDeadDrop();
//    }

//    protected virtual void OnDeadDrop()
//    {
//        Vector3 dropPos = this.transform.position;
//        Quaternion dropRot = this.transform.rotation;
//        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.dropList, dropPos, dropRot);
//    }
//    protected virtual void OnDeadFX()
//    {
//        string fxName = this.GetOnDeadFXName();
//        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,transform.rotation);
//        fxOnDead.gameObject.SetActive(true);
//    }
//    protected virtual string GetOnDeadFXName()
//    {
//        return FXSpawner.enemyDisappearFX;

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceiver : DameReceiver
{
    [Header("EnemyDameReceiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected EnemyCtrl EnemyCtrl => enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;

        // Tìm EnemyCtrl trong parent hoặc ancestor để tránh null
        enemyCtrl = transform.GetComponentInParent<EnemyCtrl>();
        if (enemyCtrl == null)
        {
            Debug.LogWarning($"{name}: Không tìm thấy EnemyCtrl trong parent!");
        }
        else
        {
            Debug.Log($"{name}: LoadEnemyCtrl thành công");
        }
    }

    protected override void ReBorn()
    {
        if (enemyCtrl != null && enemyCtrl.EnemySO != null)
        {
            maxHP = enemyCtrl.EnemySO.maxHp;
        }
        else
        {
            Debug.LogWarning($"{name}: EnemySO chưa được gán!");
        }
        base.ReBorn();
    }

    protected override void OnDead()
    {
        OnDeadFX();

        if (enemyCtrl != null && enemyCtrl.EnemyDespawn != null)
        {
            enemyCtrl.EnemyDespawn.DeSpawnObject();
        }
        else
        {
            Debug.LogWarning($"{name}: EnemyDespawn chưa được gán!");
        }

        OnDeadDrop();
    }

    protected virtual void OnDeadDrop()
    {
        if (enemyCtrl != null && enemyCtrl.EnemySO != null)
        {
            Vector3 dropPos = transform.position;
            Quaternion dropRot = transform.rotation;
            ItemDropSpawner.Instance.Drop(enemyCtrl.EnemySO.dropList, dropPos, dropRot);
        }
        else
        {
            Debug.LogWarning($"{name}: Không thể drop item vì EnemySO null!");
        }
    }

    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        if (fxOnDead != null)
        {
            fxOnDead.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"{name}: FXSpawner không spawn được FX {fxName}");
        }
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.enemyDisappearFX;
    }
}
