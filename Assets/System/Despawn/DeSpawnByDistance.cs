using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByDistance : DeSpawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCam();
    }
    protected virtual void LoadCam()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;

    }
    protected override bool CanDeSpawn()
    {
        this.distance = Vector3.Distance(this.transform.position, this.mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
