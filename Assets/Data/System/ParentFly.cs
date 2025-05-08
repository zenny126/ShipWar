using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ParentFly : ZennyMonoBehavior
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] private Vector3 direction = Vector3.right;
    private void Update()
    {
        this.transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
    }
}
