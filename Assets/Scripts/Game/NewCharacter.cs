using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NewCharacter : MonoBehaviour
{
    public Transform Bg;
    public Image ImgReview;
    public Text textDamage;
    public Sprite[] Img;
    // public int Damage;

    public void check(int id, int Damage)
    {
        Vector3 pos = GameObject.Find("ButtonInfo").transform.position;
        Bg.transform.position = pos;
        Bg.transform.DOMove(transform.position, 0.3f)
        .OnComplete(() =>
        {
            Game.game.CheckPause(false);
        });
        LibraryMy.EffectScaleObjectOn(Bg.transform, 0.3f, 1.2f);
        ImgReview.sprite = Img[id];
        ImgReview.SetNativeSize();
        textDamage.text = $"{Damage}";
    }

    public void onClickButtonX()
    {
        Vector3 pos = GameObject.Find("ButtonInfo").transform.position;
        Bg.transform.DOMove(pos, 0.3f);
        LibraryMy.EffectScaleObjectOff(Bg.transform, 0.3f, 0, () => Off());
    }

    public void Off()
    {
        gameObject.SetActive(false);
        Game.game.CheckPause(true);
    }
}
