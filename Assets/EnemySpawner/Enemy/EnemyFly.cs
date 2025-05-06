using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 3f;
    }
}
