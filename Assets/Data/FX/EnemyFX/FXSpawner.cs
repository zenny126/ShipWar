using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }
    public static string FX1 = "EnemyDisappearFX";
    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("EnemySpawner already exists");
        FXSpawner.instance = this;
    }
}
