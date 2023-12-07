using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    private Image ImgReview;
    [SerializeField]
    private Text TextName;
    [SerializeField]
    private Text TextHP;
    [SerializeField]
    private Text TextDame;
    [SerializeField]
    private GameObject Lock;
    [SerializeField]
    private GameObject BaseAtt;
    public Sprite[] SprChars;
    public int ID = 0;
    // Start is called before the first frame update
    public void UpdateInfo(int id, string name, int hp, int dame, Sprite spr, bool isUnlock)
    {
        ID = id;
        TextName.text = name;
        ImgReview.sprite = spr;
        if (isUnlock)
        {
            Lock.SetActive(true);
            TextHP.text = "?";
            TextDame.text = "?";
            ImgReview.color = new Color(0, 0, 0, 172);
        }
        else
        {
            Lock.SetActive(false);
            TextHP.text = hp.ToString();
            TextDame.text = dame.ToString();
            ImgReview.color = new Color(255, 255, 255, 255);
        }
    }

    public void CreateChar()
    {
        // if (TableControl.Intance.GetBox(false) == null)
        // {
        //     return;
        // }
        // GameController.Intance.OnCreateChar(ID, TableControl.Intance.GetBox(false), false, false);
    }

    public void CommingSoon()
    {
        ImgReview.gameObject.SetActive(false);
        TextName.text = "Coming soon";
        TextName.transform.localPosition = Vector3.zero;
        BaseAtt.SetActive(false);
    }

    public void ShowNewChar(int id, int dame, string name)
    {
        Lock.SetActive(false);
        TextName.text = name;
        ImgReview.sprite = SprChars[id];
        TextDame.text = dame.ToString();
        ImgReview.color = new Color(255, 255, 255, 255);
    }
    // public void ShowNewChar(int hp, int dame, Sprite spr)
    // {
    //     ImgReview.sprite = spr;
    //     TextHP.text = hp.ToString();
    //     TextDame.text = dame.ToString();
    //     ImgReview.color = new Color(255, 255, 255, 255);
    // }

    public void CheckImgReview(int id, string name)
    {
        ImgReview.sprite = SprChars[id];
        TextName.text = name;
        Unlock();
    }

    public void Unlock()
    {
        Lock.SetActive(true);
        TextHP.text = "?";
        TextDame.text = "?";
        ImgReview.color = new Color(0, 0, 0, 172);
    }
}
