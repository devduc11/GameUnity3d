using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCharacter : MonoBehaviour
{
    public Transform Bg;
    public Image ImgReview;
    public Text textDamage;
    public Sprite[] Img;
    // public int Damage;

    public void check(int id, int Damage)
    {
        LibraryMy.EffectScaleObjectOn(Bg.transform, 0.3f, 1.2f);
        // ImgReview.sprite = Img[id];
        ImgReview.SetNativeSize();
        textDamage.text = $"{Damage}";
    }

    public void onClickButtonX()
    {
        LibraryMy.EffectScaleObjectOff(Bg.transform, 0.3f, 0, () => Off());
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }
}
