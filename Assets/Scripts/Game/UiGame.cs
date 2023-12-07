using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGame : MonoBehaviour
{
    public Text TextCoin;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void UpdateCoin(double coin)
    {
        string result = ShortenMoney.ConvertCoin(coin);
        TextCoin.text = result;
    }
}
