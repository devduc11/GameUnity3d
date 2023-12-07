using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
    public Text TextCoin;
    public GameObject PopupInfo;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void UpdateCoin(double coin)
    {
        string result = ShortenMoney.ConvertCoin(coin);
        TextCoin.text = result;
    }

    public void ShowInfo()
    {
        PopupInfo.SetActive(true);
        PopupInfo.GetComponent<CharacterInfo>().CheckShow();
    }
}
