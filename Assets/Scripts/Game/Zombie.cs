using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animator;
    public float speed; // Tốc độ di chuyển
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        AniIsMove();
    }

    void FixedUpdate()
    {
        // Tạo một vector di chuyển chỉ theo chiều Z
        Vector3 movement = new Vector3(0f, 0f, 1f); // Di chuyển về phía trước theo trục Z

        // Áp dụng di chuyển cho đối tượng
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public void AniIsMove()
    {
        animator.SetBool("IsMove", true);
        animator.SetBool("IsDeath", false);
    }

    public void AniIsDeath()
    {
        animator.SetBool("IsMove", false);
        animator.SetBool("IsDeath", true);
    }
}
