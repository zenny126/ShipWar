using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 10f;
    }
}

