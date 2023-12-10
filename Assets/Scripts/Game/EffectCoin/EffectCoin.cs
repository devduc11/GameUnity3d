using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EffectCoin : MonoBehaviour
{
    [SerializeField]
    private Transform TextCoin;
    public Vector3 posStart;

    void Start()
    {
        posStart = transform.position;
        Reset();
    }

    public void Reset()
    {
        this.GetComponent<Animator>().enabled = true;
    }
    public void Done()
    {
        this.GetComponent<Animator>().enabled = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).DOMove(TextCoin.position, 1f).OnComplete(() =>
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).position = posStart;
                }
                this.GetComponent<Animator>().enabled = true;
                gameObject.SetActive(false);
            });
        }
    }
}
