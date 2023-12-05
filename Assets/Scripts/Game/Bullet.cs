using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = -10;
    }

    void FixedUpdate()
    {
        // Lấy giá trị trục Z hiện tại của đối tượng
        float currentZ = transform.position.z;

        // Tính toán di chuyển chỉ theo chiều Z
        float newZ = currentZ - speed * Time.deltaTime;

        // Tạo một vector mới với giá trị Z đã được tính toán
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZ);

        // Áp dụng di chuyển cho đối tượng
        transform.position = newPosition;
    }
}
