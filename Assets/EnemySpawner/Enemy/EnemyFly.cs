using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFly : ParentFly
{
    [SerializeField] private float enemyFlyspeed = 1.5f;
    [SerializeField] protected GameCtrl gameCtrl;
    [SerializeField] protected float randomRange = 7f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGameCtrl();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = enemyFlyspeed;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDrirection();
    }
    protected virtual void LoadGameCtrl()
    {
        if (gameCtrl != null) return;
        gameCtrl = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        Debug.Log("Load GameCtrl");
    }
    protected virtual void GetFlyDrirection()
    {
        Vector3 camPos = this.gameCtrl.MainCamera.transform.position;
        Vector3 objpos = transform.parent.position;
        camPos.x += Random.Range(-this.randomRange, randomRange);
        camPos.y += Random.Range(-this.randomRange, randomRange);

        Vector3 direction = camPos - objpos;
        direction.Normalize();
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.parent.rotation = Quaternion.Euler(0, 0, rotZ);
        //Debug.DrawLine(camPos, objpos, Color.red, 2f);
    }
}