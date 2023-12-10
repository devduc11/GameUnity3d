using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isCheckBox;
    public int idBox;
    // Start is called before the first frame update
    void Start()
    {
        isCheckBox = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void checkSpriteRenderer(bool bl)
    {
        spriteRenderer.enabled = bl;
        isCheckBox = bl;
    }
}
