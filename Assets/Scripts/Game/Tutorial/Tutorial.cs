using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Transform hand1, MageParent, hand2;

    public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        isPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            if (MageParent.childCount >= 2)
            {
                hand1.gameObject.SetActive(false);
                hand2.gameObject.SetActive(true);
            }
            else if (MageParent.childCount < 2)
            {
                hand1.gameObject.SetActive(true);
                hand2.gameObject.SetActive(false);
            }
        }
    }

    public void check(bool bl)
    {
        isPause = bl;
        hand1.gameObject.SetActive(bl);
        hand2.gameObject.SetActive(bl);
    }
}
