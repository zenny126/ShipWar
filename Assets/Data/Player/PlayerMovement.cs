using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Vector3 targetPos;
    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.Moving();
        this.LookAtTarget();
    }
    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MousePos;
        this.targetPos.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPos, speed * Time.deltaTime);
        transform.parent.position = newPos;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 dir = this.targetPos - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
