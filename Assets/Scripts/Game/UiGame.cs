using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
    public Text TextCoin, TextLevel;
    public GameObject PopupInfo;
    public Victory victory;
    public Lose lose;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateCoin(double coin)
    {
        string result = ShortenMoney.ConvertCoin(coin);
        TextCoin.text = result;
    }

    public void UpdateLevel(int level)
    {
        TextLevel.text = $"Stage: {level}";
    }

    public void ShowInfo()
    {
        PopupInfo.SetActive(true);
        PopupInfo.GetComponent<CharacterInfo>().CheckShow();
    }

    public void Victory(double coin)
    {
        victory.gameObject.SetActive(true);
        victory.check(coin);
    }

    public void Lose(double coin)
    {
        lose.gameObject.SetActive(true);
        lose.check(coin);
    }
}
