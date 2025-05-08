using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get => _instance; }

    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos { get => mousePos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    // Start is called before the first frame update
    protected void Awake()
    {
        InputManager._instance = this;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetMousePos();
    }
    private void Update()
    {
        this.GetMouseDown();
    }
    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
