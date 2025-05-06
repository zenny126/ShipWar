using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : DeSpawn
{
    protected override bool CanDeSpawn()
    {
        return false;
    }
}
