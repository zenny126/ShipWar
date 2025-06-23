using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 0f, 100f); // Xoay quanh trục Z

    void Update()
    {
        // Xoay đối tượng mỗi khung hình
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
