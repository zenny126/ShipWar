using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected Vector3 targetPos;
    protected Vector3 moveInput;
    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.GetMoveInput();
        this.Moving();
        this.LookAtTarget();
    }
    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MousePos;
        this.targetPos.z = 0;
    }
    //protected virtual void Moving()
    //{
    //    Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPos, speed * Time.deltaTime);
    //    transform.parent.position = newPos;
    //}
    protected virtual void GetMoveInput()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        moveInput = new Vector3(h, v, 0).normalized;
    }

    protected virtual void Moving()
    {
        Vector3 newPos = transform.parent.position + moveInput * speed * Time.deltaTime;
        transform.parent.position = newPos;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 dir = this.targetPos - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
