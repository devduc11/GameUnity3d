using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animator;
    public Transform Boder;
    public GameObject effect;
    public float speed, minHp, maxHp; // Tốc độ di chuyển
    public bool isStop;
    public double coin;
    // Start is called before the first frame update
    void Start()
    {
        isStop = true;
        animator = GetComponent<Animator>();
        AniIsMove();
    }

    void FixedUpdate()
    {
        if (isStop)
        {
            // Tạo một vector di chuyển chỉ theo chiều Z
            Vector3 movement = new Vector3(0f, 0f, 1f); // Di chuyển về phía trước theo trục Z

            // Áp dụng di chuyển cho đối tượng
            transform.Translate(movement * speed * Time.deltaTime);
        }
        // checkHp();
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

    public void updateHpItems(float index)
    {
        minHp = Mathf.Clamp(index, 0, maxHp);
        float x = minHp / maxHp;
        Boder.GetChild(0).transform.localScale = new Vector3(x, 1, 1);
    }

    public void checkHp(int Damage)
    {
        updateHpItems(minHp - Damage);
        if (minHp == 0)
        {
            Game.game.checkNext(coin);
            transform.GetComponent<BoxCollider>().enabled = false;
            isStop = false;
            AniIsDeath();
            Boder.gameObject.SetActive(false);
            DOVirtual.DelayedCall(1f, () =>
            {
                Destroy(gameObject);
            });
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            effect.SetActive(true);
            DOVirtual.DelayedCall(0.5f, () =>
            {
                effect.SetActive(false);
            });
            Bullet bullet = other.GetComponent<Bullet>();
            // print(bullet.Damage);
            checkHp(bullet.Damage);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "CheckOver")
        {
            isStop = false;
            Game.game.CheckPause(false);
            Game.game.CheckOver();
        }
    }

}
