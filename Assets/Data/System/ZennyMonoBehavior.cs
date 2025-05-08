using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZennyMonoBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //for overriding
    }
    protected virtual void ResetValue()
    {
        //for overriding
    }
    protected virtual void OnEnable()
    {
        //for overriding
    }
    protected virtual void Start()
    {
        //for overriding
    }
}
