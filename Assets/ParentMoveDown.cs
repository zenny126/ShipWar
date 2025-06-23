using UnityEngine;

public class ParentMoveDown : MonoBehaviour 
{
    public float speed = 1f; // Tốc độ di chuyển xuống

    void Start()
    {
       
        transform.parent.rotation = Quaternion.identity;
    }
    void Update()
    {
        // Di chuyển obj theo trục y hướng xuống (Vector3.down = (0, -1, 0))
        transform.parent.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
